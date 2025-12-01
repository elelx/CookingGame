using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CustomerInteractionManager : MonoBehaviour
{
    public string[] MenuItems;

    public TMP_Text customerText;
    public GameObject targetInputField;

    public GameObject[] MenuButtons; //8
    private int[] TargetQuestionNums;

    //Prefrerence Quesions
    public void StartPrefrenceQuestions()
    {
        Debug.Log("Questions Start");
        TargetQuestionNums = GetThreeRandomNumbers(); //Gets 3 random numbers, no repeats
        PrefrenceQuestions(TargetQuestionNums[0]);
        PrefrenceQuestions(TargetQuestionNums[1]);
        PrefrenceQuestions(TargetQuestionNums[2]);
    }

    void PrefrenceQuestions(int QuestionNum)
    {
        MenuButtons[QuestionNum].SetActive(true); //Buttons Appear
        Button targetButton = MenuButtons[QuestionNum].GetComponent<Button>();
        targetButton.interactable = true;
    }

    int[] GetThreeRandomNumbers()
    {
        List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, };

        // Shuffle the list
        for (int i = numbers.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            (numbers[i], numbers[rand]) = (numbers[rand], numbers[i]);
        }

        // Return the first 3
        return numbers.GetRange(0, 3).ToArray();
    }

    //ACTIVATE AND DEACTIVATE INPUT FIELD
    public void ToggleInputField()
    {
        if (targetInputField == false)
        {
            targetInputField.SetActive(true);
        }
        else
        {
            targetInputField.SetActive(false);
        }
    }

    //LOG RECIPES: UNSORTED FOR BUTTON PURPOSES
    public void LogRecipe1()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[0];
        customerScript.ItemResponce();
    }

    public void LogRecipe2()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[1];
        customerScript.ItemResponce();
    }

    public void LogRecipe3()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[2];
        customerScript.ItemResponce();
    }

    public void LogRecipe4()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[3];
        customerScript.ItemResponce();
    }

    public void LogRecipe5()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[4];
        customerScript.ItemResponce();
    }

    public void LogRecipe6()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[5];
        customerScript.ItemResponce();
    }

    public void LogRecipe7()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[6];
        customerScript.ItemResponce();
    }

    public void LogRecipe8()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[7];
        customerScript.ItemResponce();
    }


}
