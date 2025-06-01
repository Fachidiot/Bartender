using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe Data", menuName = "Scriptable Object/Recipe Data", order = int.MaxValue)]
public class RecipeData : ScriptableObject
{
    [SerializeField]
    private Dictionary<LiquidData, float> inputLiquids = new Dictionary<LiquidData, float>();

    // ����ȭ�� ���� ����Ʈ
    [SerializeField]
    private List<LiquidData> keys = new List<LiquidData>();

    [SerializeField]
    private List<float> values = new List<float>();

    // ����ȭ�Ǳ� ���� ȣ���
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        foreach (var kvp in inputLiquids)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }

    // ��ø��������� �Ŀ� ȣ���
    public void OnAfterDeserialize()
    {
        inputLiquids = new Dictionary<LiquidData, float>();

        for (int i = 0; i < keys.Count; i++)
        {
            inputLiquids[keys[i]] = values[i];
        }
    }
}
