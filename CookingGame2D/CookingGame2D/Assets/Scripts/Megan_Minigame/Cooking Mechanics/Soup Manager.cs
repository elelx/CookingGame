using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoupManager : MonoBehaviour
{
    [Header("Assign all Recipe MonoBehaviours here")]
    public Recipe[] recipes;

    [Header("Pot visuals")]
    public SpriteRenderer potRenderer;
    public Sprite potIdleSprite;
    public Sprite potCookingSprite;

    private List<string> currentPicked = new List<string>();
    private Recipe activeRecipe = null;

    string Norm(string s) => s.Trim().ToLower();

    void Start()
    {
        // Make sure NO soup is visible at the start
        foreach (var r in recipes)
        {
            if (r.soupPrefab != null)
                r.soupPrefab.SetActive(false);
        }
    }

    public void AddIngredient(string ingredient)
    {
        // If soup is already done, no more ingredients accepted
        if (activeRecipe != null) return;

        currentPicked.Add(Norm(ingredient));

        // Change pot visual
        potRenderer.sprite = potCookingSprite;

        CheckRecipes();
    }

    void CheckRecipes()
    {
        foreach (var r in recipes)
        {
            if (r.isTrash) continue;

            // Only match when EXACT number of ingredients chosen
            if (IsMatch(r))
            {
                MakeSoup(r);
                return;
            }
        }

        // Trash logic: only when menu can’t match and at least 2 items
        var trash = recipes.FirstOrDefault(r => r.isTrash);
        if (trash != null && currentPicked.Count >= 2)
        {
            MakeSoup(trash);
        }
    }

    bool IsMatch(Recipe r)
    {
        // Must have EXACT ingredient count
        if (r.requiredIngredients.Count != currentPicked.Count)
            return false;

        // Compare sorted lists
        var required = r.requiredIngredients.Select(Norm).ToList();
        var picked = currentPicked.ToList();

        required.Sort();
        picked.Sort();

        return required.SequenceEqual(picked);
    }

    void MakeSoup(Recipe r)
    {
        activeRecipe = r;

        // Hide all soups first
        foreach (var recipe in recipes)
        {
            if (recipe.soupPrefab != null)
                recipe.soupPrefab.SetActive(false);
        }

        // Show the CORRECT soup
        if (r.soupPrefab != null)
            r.soupPrefab.SetActive(true);
    }

    public void ServeSoup()
    {
        // Deactivate all soups
        foreach (var recipe in recipes)
        {
            if (recipe.soupPrefab != null)
                recipe.soupPrefab.SetActive(false);
        }

        // Reset pot
        potRenderer.sprite = potIdleSprite;

        currentPicked.Clear();
        activeRecipe = null;
    }
}
