using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable.Recipes
{
    [CreateAssetMenu(fileName = "Recipe Data", menuName = "Scriptable Object/Recipe Data", order = int.MaxValue)]
    public class RecipeData : ScriptableObject
    {
        [Serializable]
        public struct Ingredient
        {
            public LiquidData liquid;
            public float amount;
        }

        [Header("Ĭ���� �̹���")]
        public Sprite cocktailImage;

        [Header("���")]
        [SerializeField]
        private List<Ingredient> ingredients = new();


        // Dictionary�� ��ȯ�ؼ� ��� (��Ÿ�� �뵵)
        public Dictionary<LiquidData, float> GetLiquidDictionary()
        {
            Dictionary<LiquidData, float> dict = new();
            foreach (var item in ingredients)
            {
                if (item.liquid != null)
                    dict[item.liquid] = item.amount;
            }
            return dict;
        }
    }
}
