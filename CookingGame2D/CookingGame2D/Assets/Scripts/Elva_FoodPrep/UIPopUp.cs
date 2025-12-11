using UnityEngine;

public class UIPopUp : MonoBehaviour
{

    public FoodPrepRotation foodPrep;
    public GameObject kitchenPrepUI;  
    public GameObject foodPrepUI;     

    private static bool kitchenPrepShown = false;

    void Start()
    {
        kitchenPrepUI.SetActive(false);
        foodPrepUI.SetActive(false);
    }

    void Update()
    {
        KitchenPrepPopup();
       FoodPrepPopup();
    }

   
    void KitchenPrepPopup()
    {
        if (foodPrep == null || foodPrep.testGme == null) return;

        bool c1Active = foodPrep.testGme.c1;
        bool p4Active = foodPrep.testGme.p4;

        if (!kitchenPrepShown && c1Active && p4Active)
        {
            kitchenPrepUI.SetActive(true);
            kitchenPrepShown = true; 
        }

        if (!c1Active || !p4Active)
        {
            kitchenPrepUI.SetActive(false);
        }
    }

   
    void FoodPrepPopup()
    {
        if (foodPrep == null || foodPrep.testGme == null) return;

        bool c2Active = foodPrep.testGme.c2;
        bool p5Active = foodPrep.testGme.p5;

        if (c2Active && p5Active)
        {
            if (Inventory.Instance != null && Inventory.Instance.AllIngredientsZero())
            {
                foodPrepUI.SetActive(true);
            }
            else
            {
                foodPrepUI.SetActive(false);
            }
        }
        else
        {
            foodPrepUI.SetActive(false);
        }
    }

}


