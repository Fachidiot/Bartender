using System.Collections.Generic;
using UnityEngine;
using Scriptable.Recipes;

namespace _RecipeManagers
{
    /// ��� �����Ǹ� �����ϴ� �߾� ������
    public class RecipeManager : MonoBehaviour
    {
        [Header("��� ��ϵ� ������ ����Ʈ")]
        [SerializeField]
        private List<RecipeData> allRecipes;

        /// �ܺο��� ��ü ������ ��ȸ ����
        public List<RecipeData> AllRecipes => allRecipes;

        /// �������� �ϳ��� ������ ��ȯ
        public RecipeData GetRandomRecipe()
        {
            if (allRecipes == null || allRecipes.Count == 0)
            {
                Debug.LogWarning("[RecipeManager] ������ ����� ��� �ֽ��ϴ�.");
                return null;
            }

            int randomIndex = Random.Range(0, allRecipes.Count);
            return allRecipes[randomIndex];
        }

        // Ư�� �̸��� ������ �˻�
        public RecipeData FindRecipeByName(string name)
        {
            return allRecipes.Find(recipe => recipe.name == name);
        }
    }
}