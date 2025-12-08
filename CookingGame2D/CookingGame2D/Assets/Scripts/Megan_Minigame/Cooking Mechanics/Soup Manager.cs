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

    [Header("Infinite Ingredients (no inventory)")]
    public List<string> infiniteIngredients;

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

    public AudioSource sfx;
    public AudioClip emptyClip;
    public AudioClip addIngredientClip;
  



    void Start()
    {
        potRenderer.sprite = potIdleSprite;

        if (resultButtonImage != null)
            resultButtonImage.enabled = false;

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

        bool isInfinite = infiniteIngredients
            .Select(Norm)
            .Contains(norm);

        if (!isInfinite)
        {
            if (!Inventory.Instance.HasItem(norm))
            {
                PlayEmptyFeedback(norm);
                return;
            }

            Inventory.Instance.UseItem(norm);
        }

        currentPicked.Add(norm);

        if (ingredientLookup.ContainsKey(norm))
            ingredientLookup[norm].SetActive(true);

        potRenderer.sprite = potCookingSprite;

        if (sfx && addIngredientClip)
            sfx.PlayOneShot(addIngredientClip);

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


    void PlayEmptyFeedback(string ingredient)
    {
        if (sfx && emptyClip)
            sfx.PlayOneShot(emptyClip);

        Debug.Log("No more " + ingredient);
    }

    public void StartOverSoup()
    {
        if (currentPicked.Count == 0) return;

        currentPicked.Clear();
        activeRecipe = null;

        potRenderer.sprite = potIdleSprite;

        if (resultButtonImage != null)
        {
            resultButtonImage.enabled = false;
        }
  

        foreach (var obj in ingredientSpriteObjects)
        {
            obj.SetActive(false);
        }
        

 
    }



}
