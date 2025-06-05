using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;

    public void SpawnNPC()
    {
        GameObject npcObj = Instantiate(npcPrefab, transform.position, Quaternion.identity);

        NPCController npcController = npcObj.GetComponent<NPCController>();

        // 1. Spawn 위치 저장
        npcController.npcData.spawnPoint = this.transform;

        // 2. 초기화
        npcController.npcData.ResetNPCData();  // 딜레이 등 초기 설정 초기화
        npcController.stateMachine.ChangeState(new MoveToSeatState(npcController));

        Debug.Log("NPC Spawn 완료 및 초기 상태 설정");
    }
}
