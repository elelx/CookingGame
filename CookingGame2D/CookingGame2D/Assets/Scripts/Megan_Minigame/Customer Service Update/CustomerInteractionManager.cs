using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CustomerInteractionManager : MonoBehaviour
{
    [Header("Dialoge")]
    public TMP_Text customerText;
    public GameObject targetInputField;
    public GameObject Background;
    public TMP_Text customerNameText;
    public GameObject customerNamePlate;

    [Header("Menu Items")]
    public string[] MenuItems;

    [Header("Menu Questions")]
    public GameObject[] MenuButtons; //8
    private int[] TargetQuestionNums;
    public GameObject customerReactionImage;

    [Header("Small Talk")]
    private int currentQuestionNum;
    public GameObject smallTalkButtonObj;
    private Button smallTalkButton;

    public static bool playerIsTyping = true;

    public GameObject submitSoupText;

    private void Start()
    {
        StartInteraction();
    }

    private void ResetInteraction()
    {
        submitSoupText.SetActive(false);
        customerReactionImage.SetActive(false);

        //Deactivate Small Talk Button
        smallTalkButton = smallTalkButtonObj.GetComponent<Button>();
        StopSmallTalk();

        //Reset Current Question Number
        currentQuestionNum = 0;

    }

    public void EndInteraction()
    {
        //NEED TO ADD !!!!!!! Make the character Dissapear
        
        //Stop Interaction
        StopSmallTalk();

        //NEED TO ADD End Customer Profile Script

        //Hide Character UI
        customerNamePlate.SetActive(false);
    }

    public void StartInteraction()
    {
         ResetInteraction();

        //NEED TO ADD !!!!!!! Make a random character appear

        //Start Customer Introduction
        BasicCustomerManager customerManager = Object.FindFirstObjectByType<BasicCustomerManager>();
        customerManager.CustomerIntroduction();

        CustomerProfile customerProfile = Object.FindFirstObjectByType<CustomerProfile>();
        //NEED TO ADD Start Customer Profile Script

        //Assign name to UI
        customerNamePlate.SetActive(true);
        customerNameText.text = customerProfile.customerName;
        ToggleInputFieldOn();


    }

    //Small Talk

    public void QuestionsLoop()
    {
        currentQuestionNum += 1;

        if (currentQuestionNum == 3)
        {
            StartSmallTalk();
            currentQuestionNum = 0;
        }
    }

    public void StartSmallTalk()
    {
        smallTalkButtonObj.SetActive(true); //Small Talk Button Appears
        smallTalkButton.interactable = true;
        submitSoupText.SetActive(true);
    }

    public void StopSmallTalk()
    {
        smallTalkButtonObj.SetActive(false); //Small Talk Button Appears
        smallTalkButton.interactable = false;
        submitSoupText.SetActive(false);
    }

    public void SmallTalk()
    {
        customerReactionImage.SetActive(false);
        BasicCustomerManager customerScript = Object.FindFirstObjectByType<BasicCustomerManager>(); //Grab Active Customer Profile Script
        customerScript.ReturnDialogue();
    }

    //Prefrerence Quesions
    //public void StartPrefrenceQuestions()
    //{
    //    customerReactionImage.SetActive(true);

    //    Debug.Log("Questions Start");
    //    TargetQuestionNums = GetThreeRandomNumbers(); //Gets 3 random numbers, no repeats
    //    PrefrenceQuestions(TargetQuestionNums[0]);
    //    PrefrenceQuestions(TargetQuestionNums[1]);
    //    PrefrenceQuestions(TargetQuestionNums[2]);
    //}
    public void StartPrefrenceQuestions()
    {
        customerReactionImage.SetActive(true);
        Debug.Log("Questions Start");

        TargetQuestionNums = GetThreeRandomNumbers(); //Gets 3 random numbers, no repeats

        for (int i = 0; i < MenuButtons.Length; i++)
        {
            Button btn = MenuButtons[i].GetComponent<Button>();
            btn.interactable = false; // Reset interactable for all buttons
        }

        // Enable only the target buttons for this customer
        for (int i = 0; i < TargetQuestionNums.Length; i++)
        {
            int index = TargetQuestionNums[i];
            MenuButtons[index].SetActive(true);
            MenuButtons[index].GetComponent<Button>().interactable = true;
        }
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
            Debug.Log("test toggle input");

            targetInputField.SetActive(true);
            playerIsTyping = true;
        }
        else
        {
            targetInputField.SetActive(false);
            playerIsTyping = false;
        }
    }

    public void ToggleInputFieldOn()
    {
        Debug.Log("test toggle input");

        targetInputField.SetActive(true);
        playerIsTyping = true;
    }


    //LOG RECIPES: UNSORTED FOR BUTTON PURPOSES
    public void LogRecipe1()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[0];
        customerScript.ItemResponceUnscored();
        QuestionsLoop();
    }

    public void LogRecipe2()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[1];
        customerScript.ItemResponceUnscored();
        QuestionsLoop();
    }

    public void LogRecipe3()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[2];
        customerScript.ItemResponceUnscored();
        QuestionsLoop();
    }

    public void LogRecipe4()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[3];
        customerScript.ItemResponceUnscored();
        QuestionsLoop();
    }

    public void LogRecipe5()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[4];
        customerScript.ItemResponceUnscored();
        QuestionsLoop();
    }

    public void LogRecipe6()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[5];
        customerScript.ItemResponceUnscored();
        QuestionsLoop();
    }

    public void LogRecipe7()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[6];
        customerScript.ItemResponceUnscored();
        QuestionsLoop();
    }

    public void LogRecipe8()
    {
        CustomerProfile customerScript = Object.FindFirstObjectByType<CustomerProfile>(); //Grab Active Customer Profile Script
        customerScript.targetMenuItem = MenuItems[7];
        customerScript.ItemResponceUnscored();
        QuestionsLoop();
    }

}
