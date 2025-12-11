using UnityEngine;

public class AppearIngre : MonoBehaviour
{
    public GameObject[] ingredients;

    public void ActivateIngredient(int index)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            bool active = (i == index);

            ingredients[i].SetActive(active);

            if (!active)
            {
                var controller = ingredients[i].GetComponent<MultiCutController>();
                if (controller)
                    controller.ResetIngredient();
            }
        }
    }

    public void ResetAllIngredients()
    {
        foreach (var ing in ingredients)
        {
            ing.SetActive(false);

            var controller = ing.GetComponent<MultiCutController>();
            if (controller)
                controller.ResetIngredient();
        }
    }

}
