using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    [Header("Soup Settings")]
    public string soupName;

    [Header("Required Ingredients (names)")]
    public List<string> requiredIngredients = new List<string>();

    [Header("Output")]
    public GameObject soupPrefab;
    public Sprite soupSprite;

    [Header("Is this the Trash recipe?")]
    public bool isTrash;
}
