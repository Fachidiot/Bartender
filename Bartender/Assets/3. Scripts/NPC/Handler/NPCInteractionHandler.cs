using UnityEngine;

public class NPCInteractionHandler : MonoBehaviour
{
/*    private NPCController npc;
    private float checkRadius = 0.5f;

    private void Awake()
    {
        npc = GetComponent<NPCController>();
    }

    // 음료 수령 감지
    public bool CheckDrinkReceived()
    {
        if (npc.npcData.drinkCheckPoint == null) return false;

        Collider[] hits = Physics.OverlapSphere(npc.npcData.drinkCheckPoint.position, checkRadius);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Drink"))
            {
                Debug.Log("[NPCInteraction] 음료 감지됨");
                return true;
            }
        }

        return false;
    }

    // 음료 점수에 따른 반응 처리
    public void EvaluateDrink(float score)
    {
        npc.npcData.drinkScore = score;

        if (score >= 8f)
        {
            npc.uiHandler.ShowEmotion("Happy");
        }
        else if (score >= 5f)
        {
            npc.uiHandler.ShowEmotion("Normal");
        }
        else
        {
            npc.uiHandler.ShowEmotion("Sad");
        }

        Debug.Log($"[NPCInteraction] 음료 평가 완료: {score}");
    }

    // 주문 아이콘 표시
    public void ShowOrderIcon(Sprite cocktailSprite)
    {
        npc.uiHandler.ShowOrder(cocktailSprite);
    }

    // 주문 아이콘 숨기기
    public void HideOrderIcon()
    {
        npc.uiHandler.HideOrder();
    }*/
}
