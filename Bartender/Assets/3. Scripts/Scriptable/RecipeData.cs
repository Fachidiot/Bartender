using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe Data", menuName = "Scriptable Object/Recipe Data", order = int.MaxValue)]
public class RecipeData : ScriptableObject
{
    [SerializeField]
    private Dictionary<LiquidData, float> inputLiquids = new Dictionary<LiquidData, float>();

    // 직렬화를 위한 리스트
    [SerializeField]
    private List<LiquidData> keys = new List<LiquidData>();

    [SerializeField]
    private List<float> values = new List<float>();

    // 직렬화되기 전에 호출됨
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

    // 디시리얼라이즈된 후에 호출됨
    public void OnAfterDeserialize()
    {
        inputLiquids = new Dictionary<LiquidData, float>();

        for (int i = 0; i < keys.Count; i++)
        {
            inputLiquids[keys[i]] = values[i];
        }
    }
}
