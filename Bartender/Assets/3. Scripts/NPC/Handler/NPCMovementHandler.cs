using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class NPCMovementHandler : MonoBehaviour
{
    [Header("Exit")]
    [Tooltip("퇴장 시 이동할 문(출구)의 Transform")]
    public Transform exitPosition;

    private NavMeshAgent agent;             // 이동용 NavMesh 에이전트
    private NPCSeatManager seatManager;     // 좌석 매니저 참조

    private bool isMovingToAnchor = true;   // 현재 Anchor로 이동 중인지 여부
    private Collider targetAnchorCollider;  // 이동 대상 Anchor (콜라이더)
    private Transform currentTarget;        // 현재 목적지 (위치용)
    private Transform currentSitPoint;      // 앉을 위치 (SitPoint)

    [Header("Rotation Target")]
    [Tooltip("착석 시 NPC가 바라보는 옵젝")]
    public Transform rotationTarget; // 인스펙터에서 지정


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        seatManager = FindObjectOfType<NPCSeatManager>();

        if (seatManager == null)
            Debug.LogError("NPCSeatManager를 찾을 수 없습니다!");
    }


    // NavMesh 상의 지정 위치로 안전하게 이동합니다.
    public void MoveTo(Vector3 destination)
    {
        if (agent == null) return;

        if (NavMesh.SamplePosition(destination, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        else
        {
            Debug.LogWarning("NavMesh 위의 유효한 지점을 찾지 못했습니다.");
        }
    }


    // Anchor 콜라이더를 목적지로 하여 좌석으로 이동을 시작합니다.
    public void MoveToSeat(Collider anchorCollider, Transform sitPoint)
    {
        if (anchorCollider == null || sitPoint == null) return;

        targetAnchorCollider = anchorCollider;
        currentSitPoint = sitPoint;
        isMovingToAnchor = true;

        MoveTo(anchorCollider.transform.position);
    }

    // Anchor 도착 후 SitPoint로 NPC 위치를 즉시 이동시킵니다 (텔레포트).
    public void TeleportToSitPoint()
    {
        if (currentSitPoint == null) return;

        Debug.Log("텔포 의자로");

        currentTarget = currentSitPoint;
        isMovingToAnchor = false;

        if (agent != null)
        {
            agent.Warp(currentSitPoint.position); // NavMesh 위로 강제 이동
            agent.ResetPath();
        }
        else
        {
            transform.position = currentSitPoint.position;
        }

        RotateTowardsSitPoint();
    }

    // 현재 NavMesh 목적지에 도달했는지 판단합니다.
    public bool HasReachedDestination()
    {
        if (agent == null) return false;
        return !agent.pathPending &&
               agent.remainingDistance <= agent.stoppingDistance &&
               (!agent.hasPath || agent.velocity.sqrMagnitude < 0.2f);
    }

    // SitPoint를 기준으로 NPC의 Y축 회전만 정렬합니다.
    private void RotateTowardsSitPoint()
    {
        if (rotationTarget == null) return;

        Vector3 direction = rotationTarget.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }

    // 사용 가능한 좌석을 할당받고 Anchor 콜라이더 및 SitPoint 반환합니다.
    public (Collider anchor, Transform sitPoint) AssignSeat()
    {
        if (seatManager == null) return (null, null);
        return seatManager.AssignSeatPair();
    }

    // 사용이 끝난 좌석을 SeatManager에 반환합니다.
    public void ReleaseSeat(Transform seat)
    {
        if (seatManager != null && seat != null)
            seatManager.ReleaseSeat(seat);
    }

    // 출구로 이동합니다.
    public void MoveToExit()
    {
        if (exitPosition != null)
            MoveTo(exitPosition.position);
    }
}
