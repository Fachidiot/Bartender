using UnityEngine;
using _RecipeManagers;
using Scriptable.Recipes;

public class NPCData : MonoBehaviour
{
    [Header("NPC ����")]
    public bool isMove = false;         // ���� ������
    public bool isArrived = false;      // ���� ���� ����
    public bool isSeated = false;       // ���� �Ϸ� ���θ� ����
    public bool hasOrdered = false;     // �ֹ� �Ϸ� ����
    public bool hasDrink = false;       // ���� �޾Ҵ��� ����
    public bool isFinished = false;     // ��� �ൿ �Ϸ� ����


    [Header("���� ����")]
    public Transform spawnPoint;        //���� ����Ʈ


    [Header("���� �޴� ��ġ")]
    public Transform drinkCheckPoint; // Trigger�� ������ ����

    [Header("���� ��")]
    [Range(0f, 10f)]
    public float drinkScore = 0f;       // ���� ����

    [Header("Ÿ�̸�")]
    [Tooltip("�ֹ��ϱ� �� ��� �ð�")]
    public float orderDelay = 0f;       // �ֹ� �� ���� ������

    [Tooltip("���Ḧ ���ô� �� �ð�")]
    public float drinkDuration = 180f;  // ���ô� �ð� (3��)


    [Header("�ֹ� ����")]
    public RecipeData myOrderRecipe;    // ���� NPC�� �ֹ� ������

    private RecipeManager recipeManager;


    // NPC �ʱ�ȭ (���� ��)
    public void ResetNPCData()
    {
        orderDelay = Random.Range(5f, 7f);
        drinkDuration = Random.Range(120f, 240f);

        isSeated = false;
        drinkScore = 0f;
        hasOrdered = false;
        hasDrink = false;
        isFinished = false;
        isArrived = false;
    }

    private void Start()
    {
        recipeManager = FindObjectOfType<RecipeManager>();

        // ������ �� ���� ���� �ʱ�ȭ
        if (orderDelay == 0f)
            orderDelay = Random.Range(1f, 5f);

        if (drinkDuration == 180f) // �⺻���̸�
            drinkDuration = Random.Range(120f, 240f);
    }


    // ������ ������ ����
    public void SetRandomRecipe()
    {
        if (recipeManager == null)
            recipeManager = FindObjectOfType<RecipeManager>();

        myOrderRecipe = recipeManager.GetRandomRecipe();
    }

    // �ֹ��� ���� �̹��� ��ȯ
    public Sprite GetOrderedDrinkSprite()
    {
        return myOrderRecipe != null ? myOrderRecipe.cocktailImage : null;
    }

    // �ֹ��� ���� �̸� ��ȯ
    public string GetOrderedDrinkName()
    {
        return myOrderRecipe != null ? myOrderRecipe.name : "";
    }
}