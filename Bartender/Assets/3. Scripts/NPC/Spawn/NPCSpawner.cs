using System.Collections;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [Header("NPC ������")]
    public GameObject npcPrefab;

    [Header("���� ��Ÿ��")]
    public float minSpawnCooldown = 120f;
    public float maxSpawnCooldown = 180f;

    [Header("���� �̵� Ÿ��")]
    [Tooltip("NPC�� ������ ��ġ")]
    [SerializeField] private Transform exitPosition;

    [Tooltip("NPC�� ���� �� �ٶ� �߽� ������Ʈ")]
    [SerializeField] private Transform rotationTarget;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

     // NPC �ϳ� ���� �� �ʱ�ȭ

    public void SpawnNPC()
    {
        GameObject npcObj = Instantiate(npcPrefab, transform.position, Quaternion.identity);
        NPCController npcController = npcObj.GetComponent<NPCController>();

        if (npcController == null)
        {
            Debug.LogError("NPCController�� �����տ� �������� �ʽ��ϴ�.");
            return;
        }

        // 1. Spawn ��ġ ����
        npcController.npcData.spawnPoint = this.transform;

        // 2. �̵� �ڵ鷯�� ��ġ Ÿ�� ����
        var moveHandler = npcController.movementHandler;
        if (moveHandler != null)
        {
            moveHandler.exitPosition = exitPosition;
            moveHandler.rotationTarget = rotationTarget;
        }
        else
        {
            Debug.LogWarning("NPCMovementHandler�� ������� �ʾҽ��ϴ�.");
        }

        // 3. NPC �ʱ�ȭ �� ���� ����
        npcController.npcData.ResetNPCData();
        npcController.stateMachine.ChangeState(new MoveToSeatState(npcController));

        Debug.Log("NPC Spawn �Ϸ� �� �ʱ� ���� ����");
    }


    // ���� �ð����� NPC�� �����ϴ� ��ƾ
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
