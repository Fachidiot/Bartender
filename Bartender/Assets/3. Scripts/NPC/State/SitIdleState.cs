using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SitIdleState : NpcState
{
    private float waitTimer = 0f;
    public SitIdleState(NPCController npc) : base(npc) { }

    public override void Enter()
    {
        waitTimer = 0f;

        Debug.Log("SitIdle진입 및 애니메이션 실행");
        npc.animationHandler.SetAnimation("SitIdle", true); //Trigger 파라미터 이름

        Debug.Log($"[SitAndWaitState] 주문 대기 딜레이 시작 ({npc.npcData.orderDelay}초)");

    }

    public override void Update()
    {
        // 여기에 음류 받았는지 안받았는지 확인하는 조건 (함수) 


        // 1: 주문 전이면 → 타이머 작동
        if (!npc.npcData.hasOrdered)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= npc.npcData.orderDelay)
            {
                Debug.Log("[SitIdleState] 주문 딜레이 완료 → OrderState로 전환");

                npc.animationHandler.SetAnimation("SitIdle", false);
                npc.ChangeState(new OrderState(npc));
            }

            return;
        }


        // 2: 주문은 했고, 음료는 아직 안 받음
        if (npc.npcData.hasOrdered && !npc.npcData.hasDrink)
        {
            Debug.Log("[SitIdleState] 음료 수령 대기 → WaitForDrinkState");
        }

        // 3: 주문은 했고, 음료 받았다.
        if (npc.npcData.hasOrdered && npc.npcData.hasDrink)
        {
            npc.animationHandler.SetAnimation("SitIdle", false);
            npc.ChangeState(new DrinkState(npc));
        }
    }
}

