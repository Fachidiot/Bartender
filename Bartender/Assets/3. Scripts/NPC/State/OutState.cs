using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutState : NpcState 
{
    private bool isWalking;

    public OutState(NPCController npc) : base(npc) { }

    public override void Enter()
    {
        if(npc.npcData.spawnPoint == null)
        {
            Debug.LogWarning("Exit 스폰 포인트가 비어있음");
            return;
        }

        npc.animationHandler.SetAnimation("Walk", true);
        npc.movementHandler.MoveTo(npc.npcData.spawnPoint.position);
        isWalking = true;
    }
    public override void Update()
    {
        if (!isWalking) return;

        if (npc.movementHandler.HasReachedDestination())
        {
            Debug.Log("NPC 출구 도달");

            npc.animationHandler.SetAnimation("Walk", false);

            GameObject.Destroy(npc.gameObject);
        }
    }

}
