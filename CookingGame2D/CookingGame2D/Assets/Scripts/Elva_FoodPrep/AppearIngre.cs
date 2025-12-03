using UnityEngine;

public class AppearIngre : MonoBehaviour
{
    public GameObject[] ingredients;  

    public void ActivateIngredient(int index)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].SetActive(i == index);
        }
    }
}
