using System.Collections.Generic;
using UnityEngine;
using Scriptable.Recipes;

namespace _RecipeManagers
{
    /// 모든 레시피를 관리하는 중앙 관리자
    public class RecipeManager : MonoBehaviour
    {
        [Header("모든 등록된 레시피 리스트")]
        [SerializeField]
        private List<RecipeData> allRecipes;

        /// 외부에서 전체 레시피 조회 가능
        public List<RecipeData> AllRecipes => allRecipes;

        /// 무작위로 하나의 레시피 반환
        public RecipeData GetRandomRecipe()
        {
            if (allRecipes == null || allRecipes.Count == 0)
            {
                Debug.LogWarning("[RecipeManager] 레시피 목록이 비어 있습니다.");
                return null;
            }

            int randomIndex = Random.Range(0, allRecipes.Count);
            return allRecipes[randomIndex];
        }

        // 특정 이름의 레시피 검색
        public RecipeData FindRecipeByName(string name)
        {
            return allRecipes.Find(recipe => recipe.name == name);
        }
    }
}