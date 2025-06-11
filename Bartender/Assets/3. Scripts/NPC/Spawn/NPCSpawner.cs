using System.Collections;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [Header("NPC 프리팹")]
    public GameObject npcPrefab;

    [Header("스폰 쿨타임")]
    public float minSpawnCooldown = 120f;
    public float maxSpawnCooldown = 180f;

    [Header("공통 이동 타겟")]
    [Tooltip("NPC가 퇴장할 위치")]
    [SerializeField] private Transform exitPosition;

    [Tooltip("NPC가 앉을 때 바라볼 중심 오브젝트")]
    [SerializeField] private Transform rotationTarget;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

     // NPC 하나 생성 및 초기화

    public void SpawnNPC()
    {
        GameObject npcObj = Instantiate(npcPrefab, transform.position, Quaternion.identity);
        NPCController npcController = npcObj.GetComponent<NPCController>();

        if (npcController == null)
        {
            Debug.LogError("NPCController가 프리팹에 존재하지 않습니다.");
            return;
        }

        // 1. Spawn 위치 저장
        npcController.npcData.spawnPoint = this.transform;

        // 2. 이동 핸들러에 위치 타겟 설정
        var moveHandler = npcController.movementHandler;
        if (moveHandler != null)
        {
            moveHandler.exitPosition = exitPosition;
            moveHandler.rotationTarget = rotationTarget;
        }
        else
        {
            Debug.LogWarning("NPCMovementHandler가 연결되지 않았습니다.");
        }

        // 3. NPC 초기화 및 상태 시작
        npcController.npcData.ResetNPCData();
        npcController.stateMachine.ChangeState(new MoveToSeatState(npcController));

        Debug.Log("NPC Spawn 완료 및 초기 상태 설정");
    }


    // 일정 시간마다 NPC를 생성하는 루틴
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float delay = Random.Range(minSpawnCooldown, maxSpawnCooldown);
            yield return new WaitForSeconds(delay);
            SpawnNPC();
        }
    }
}
