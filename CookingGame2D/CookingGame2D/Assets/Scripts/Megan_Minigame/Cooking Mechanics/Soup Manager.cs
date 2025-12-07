using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SoupManager : MonoBehaviour
{
    [Header("All Recipes")]
    public Recipe[] recipes;

    [Header("Pot Visuals")]
    public SpriteRenderer potRenderer;
    public Sprite potIdleSprite;
    public Sprite potCookingSprite;

    [Header("Result Button")]
    public Image resultButtonImage;

    [Header("Ingredient Sprites Inside Pot")]
    public List<string> ingredientNames;      
    public List<GameObject> ingredientSpriteObjects;

    private Dictionary<string, GameObject> ingredientLookup;

    private List<string> currentPicked = new List<string>();
    private Recipe activeRecipe = null;

    private string Norm(string s) => s.Trim().ToLower();
    public string currentSoupName => activeRecipe != null ? activeRecipe.soupName : null;

    void Start()
    {
        potRenderer.sprite = potIdleSprite;

        if (resultButtonImage != null)
            resultButtonImage.enabled = false;

        //Dictionary for ingredients
        ingredientLookup = new Dictionary<string, GameObject>();
        for (int i = 0; i < ingredientNames.Count; i++)
        {
            string key = Norm(ingredientNames[i]);
            ingredientLookup[key] = ingredientSpriteObjects[i];
            ingredientSpriteObjects[i].SetActive(false);
        }
    }

    public void AddIngredient(string ingredient)
    {
        if (activeRecipe != null) return;

        string norm = Norm(ingredient);
        currentPicked.Add(norm);

        // Show ingredient sprite inside pot
        if (ingredientLookup.ContainsKey(norm))
            ingredientLookup[norm].SetActive(true);

        potRenderer.sprite = potCookingSprite;
        CheckRecipes();
    }

    private void CheckRecipes()
    {
        foreach (var r in recipes)
        {
            if (r.isTrash) continue;

            if (IsMatch(r))
            {
                MakeSoup(r);
                return;
            }
        }

        var trash = recipes.FirstOrDefault(r => r.isTrash);

        if (trash != null && currentPicked.Count >= 5)
            MakeSoup(trash);
    }

    private bool IsMatch(Recipe r)
    {
        if (r.requiredIngredients.Count != currentPicked.Count)
            return false;

        var required = r.requiredIngredients.Select(Norm).OrderBy(x => x).ToList();
        var picked = currentPicked.OrderBy(x => x).ToList();

        return required.SequenceEqual(picked);
    }

    private void MakeSoup(Recipe r)
    {
        activeRecipe = r;

        if (resultButtonImage != null)
        {
            resultButtonImage.sprite = r.soupSprite;
            resultButtonImage.enabled = true;
        }

        Debug.Log("Soup ready: " + r.soupName);
    }

    public void ServeSoup()
    {
        activeRecipe = null;

        // Clear ingredient list
        currentPicked.Clear();

        // Reset pot sprite
        potRenderer.sprite = potIdleSprite;

        // Hide result button image
        if (resultButtonImage != null)
            resultButtonImage.enabled = false;

        // Hide all ingredient sprites in pot
        foreach (var obj in ingredientSpriteObjects)
            obj.SetActive(false);
    }

    public bool HasFinishedSoup() => activeRecipe != null;

}
