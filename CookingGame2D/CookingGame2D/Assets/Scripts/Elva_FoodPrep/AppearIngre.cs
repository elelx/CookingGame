using UnityEngine;

public class AppearIngre : MonoBehaviour
{
    public GameObject[] ingredients;
    public DragMan[] dragManagers;

    public void ActivateIngredient(int index)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            bool active = (i == index);

            ingredients[i].SetActive(active);

            if (!active && i < dragManagers.Length && dragManagers[i] != null)
            {
                dragManagers[i].ResetAll();
            }
        }
    }
}
