using UnityEngine;
using UnityEngine.UI; // UI용이면 추가

public class NPCUIHandler : MonoBehaviour
{
    public GameObject orderIcon;    //부모 오브젝트
    public SpriteRenderer orderSpriteRenderer;  // 또는 Image (UI 타입이면)

    public void ShowOrderIcon(Sprite iconSprite)
    {
        if (orderIcon != null && orderSpriteRenderer != null)
        {
            orderIcon.SetActive(true);
            orderSpriteRenderer.sprite = iconSprite;
        }
    }

    public void HideOrderIcon()
    {
        if (orderIcon != null)
            orderIcon.SetActive(false);
    }
}
