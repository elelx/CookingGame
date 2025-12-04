using TMPro;
using UnityEngine;

public class BasicCustomerManager : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text serviceText;
    public string customerServiceLine;
    public string customerResponse;

    [Header("Sprites")]
    public SpriteRenderer customerSprite;

    [Header("Scripts")]
    public CustomerInteractionManager interactionManager;

    [Header("Settings")]
    public float answerTimeLimit = 10f;
    private int angerLevel = 0;
    private float timer = 0f;

    void Update()
    {
        EmotionsTimer();
    }

    //  TYPING DIALOGE
    public bool CheckTypedAnswer(string typed)
    {
        Debug.Log("AnswerChecked");
        string correct = customerServiceLine.ToLower().Trim();
        typed = typed.ToLower().Trim();

        if (typed == correct)
        {
            ResetEmotion();
            interactionManager.ToggleInputField();
            ResetCustomerState(); //Answer is correct, customer responds and resets
            return true;
        }

        IncreaseAnger();
        return false;
    }

    public void CustomerIntroduction()
    {
        serviceText.text = customerServiceLine;
        angerLevel = 0;
        UpdateSpriteAnger();
        ResetCoversationTimer();
    }

    //DIALOGE

    public void ResetCustomerState()
    {
        angerLevel = 0;
        UpdateSpriteAnger();
        ShowCustomerDialogue();
        ResetCoversationTimer();
        interactionManager.StartPrefrenceQuestions();
    }

    public void StartOrderQuestions()
    {
        //Start order questions sequence from the other script
        interactionManager.StartPrefrenceQuestions();
    }

    public void ReturnDialogue()
    {
        ShowCustomerDialogue();
        ResetCoversationTimer();
    }

    private void ShowCustomerDialogue()
    {
        //customerText.text = Meow , Caw, Blub
        interactionManager.customerText.text = customerResponse;

    }

    //  EMOTIONS 
    private void EmotionsTimer()
    {
        //Emotions Timer
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            IncreaseAnger();
            ResetCoversationTimer();
        }
    }

    private void ResetCoversationTimer()
    {
        timer = answerTimeLimit;
    }

    private void IncreaseAnger()
    {
        angerLevel++;
        if (angerLevel > 2) angerLevel = 2;
        UpdateSpriteAnger();
    }

    private void ResetEmotion()
    {
        angerLevel = 0;
        UpdateSpriteAnger();
    }

    private void UpdateSpriteAnger()
    {
        switch (angerLevel)
        {
            case 0: customerSprite.color = new Color (1f, 1f, 1f); break;
            case 1: customerSprite.color = new Color(0.9f, 0.7f, 0.7f); break;
            case 2: customerSprite.color = new Color(0.9f, 0.5f, 0.5f); break;
        }
    }

    //EMOTIONS SCORE
    public int GetAngerScore()
    {
        //Score based on anger Level
        return angerLevel switch
        {
            0 => 3,
            1 => 2,
            2 => 1,
            _ => 1
        };
    }


}
