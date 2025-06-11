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

        [Header("칵테일 이미지")]
        public Sprite cocktailImage;

        [Header("재료")]
        [SerializeField]
        private List<Ingredient> ingredients = new();


        // Dictionary로 변환해서 사용 (런타임 용도)
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
