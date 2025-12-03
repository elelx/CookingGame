using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SoupManager : MonoBehaviour
{
    // This script handles:
    // - Pot visuals (idle vs cooking)
    // - Adding ingredients
    // - Matching ingredients to a recipe
    // - Setting the soup result sprite on the result button
    // - Resetting the pot after serving

    [Header("All Recipes")]
    public Recipe[] recipes;

    [Header("Pot Visuals")]
    public SpriteRenderer potRenderer;
    public Sprite potIdleSprite;
    public Sprite potCookingSprite;

    [Header("Result Button")]
    public Image resultButtonImage;
   

    private List<string> currentPicked = new List<string>();
    private Recipe activeRecipe = null;
    public string currentSoupName => activeRecipe != null ? activeRecipe.soupName : null;
    private string Norm(string s) => s.Trim().ToLower();


    void Start()
    {
      
        potRenderer.sprite = potIdleSprite;

        // Hide the soup result button image (no soup yet)
        if (resultButtonImage != null)
            resultButtonImage.enabled = false;
    }


    public void AddIngredient(string ingredient)
    {
        // If recipe already completed, avoid adding more ingredients
        if (activeRecipe != null) return;

        
        currentPicked.Add(Norm(ingredient));

        // Change pot visual to cooking mode
        potRenderer.sprite = potCookingSprite;
        CheckRecipes();
    }


    private void CheckRecipes()
    {
        // First check all normal recipes (non-trash)
        foreach (var r in recipes)
        {
            if (r.isTrash) continue; 

            // If ingredients match a recipe, make that soup
            if (IsMatch(r))
            {
                MakeSoup(r);
                return;
            }
        }

        // If no recipe matched, check if trash recipe should be triggered
        var trash = recipes.FirstOrDefault(r => r.isTrash);

        // Trash only applies if 5 or more wrong ingredients are added
        if (trash != null && currentPicked.Count >= 5)
            MakeSoup(trash);
    }


    private bool IsMatch(Recipe r)
    {
        // Must have the exact same number of ingredients
        if (r.requiredIngredients.Count != currentPicked.Count)
            return false;

        // Sort both ingredient lists for comparison
        var required = r.requiredIngredients.Select(Norm).OrderBy(x => x).ToList();
        var picked = currentPicked.OrderBy(x => x).ToList();

        
        return required.SequenceEqual(picked);
    }


    private void MakeSoup(Recipe r)
    {
        // Set this recipe as the final soup made
        activeRecipe = r;

        // Display soup sprite on result button
        if (resultButtonImage != null)
        {
            resultButtonImage.sprite = r.soupSprite; 
            resultButtonImage.enabled = true;        
        }

        Debug.Log("Soup ready: " + r.soupName);
    }


    public void ServeSoup()
    {
        // Reset recipe
        activeRecipe = null;

     
        currentPicked.Clear();

        
        potRenderer.sprite = potIdleSprite;

        
        if (resultButtonImage != null)
            resultButtonImage.enabled = false;
    }

   
    public bool HasFinishedSoup() => activeRecipe != null;
}
