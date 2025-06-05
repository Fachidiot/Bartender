using UnityEngine;

public class DrinkState : NpcState
{
    private float drinkTimer = 0;

    public DrinkState(NPCController npc) : base(npc) { }

    public override void Enter()
    {
        Debug.Log("DrinkState 진입");
        npc.animationHandler.SetTrigger("Drink");
    }

    public override void Update()
    {
        drinkTimer += Time.deltaTime;

        if(drinkTimer >= npc.npcData.drinkDuration)
            npc.ChangeState(new OutState(npc));


        if (npc.animationHandler.CheckFinishAnimation("Drink"))
        {
            Debug.Log("Drink 애니메이션 종료 → SitIdleState 전환");
            npc.ChangeState(new SitIdleState(npc));
        }
    }
}
