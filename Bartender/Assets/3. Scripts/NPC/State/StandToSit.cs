using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandToSit : NpcState
{
    public StandToSit(NPCController npc) : base(npc) { }
    public override void Enter()
    {
        npc.animationHandler.SetTrigger("StandToSit");

        npc.StartCoroutine(WaitForSitComplete());
    }

    private IEnumerator WaitForSitComplete()
    {
        yield return null; // 상태 전이 보장

        // StandToSit 상태로 전이될 때까지 기다리기
        while (!npc.animationHandler.CheckFinishAnimation("StandToSit"))
        {
            yield return null;
        }

        Debug.Log("SitIdle 끝!");
        npc.ChangeState(new SitIdleState(npc));
    }

}
