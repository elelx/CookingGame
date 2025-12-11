using UnityEngine;
using TMPro;

public class CustomerDialogueManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text customerText;

    [Header("Sprites")]
    public SpriteRenderer customerSprite;
    public Sprite happySprite;
    public Sprite neutralSprite;
    public Sprite angrySprite;

    [Header("Manual Book Data")]
    public ManualBookData manual;



    [Header("Settings")]
    public float answerTimeLimit = 10f;

    private int angerLevel = 0;
    private float timer = 0f;
    private int currentIndex = 0;

    void Start()
    {
        ResetDialogue();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            IncreaseAnger();
            ResetTimer();
        }
    }

    //  MAIN DIALOG 
    public bool CheckAnswer(string typed)
    {
        string correct = manual.dialoguePairs[currentIndex].reply.ToLower().Trim();
        typed = typed.ToLower().Trim();

        if (typed == correct)
        {
            ResetEmotion();
            NextDialogue();
            return true;
        }

        IncreaseAnger();
        return false;
    }

    private void NextDialogue()
    {
        currentIndex++;
        if (currentIndex >= manual.dialoguePairs.Count)
            currentIndex = 0;

        ShowDialogue();
        ResetTimer();
    }

    public void ResetDialogue()
    {
        currentIndex = 0;
        angerLevel = 0;
        UpdateSprite();
        ShowDialogue();
        ResetTimer();
    }

    private void ShowDialogue()
    {
        customerText.text = manual.dialoguePairs[currentIndex].customer;
    }

    private void ResetTimer()
    {
        timer = answerTimeLimit;
    }

    //  EMOTIONS 
    private void IncreaseAnger()
    {
        angerLevel++;
        if (angerLevel > 2) angerLevel = 2;
        UpdateSprite();
    }

    private void ResetEmotion()
    {
        angerLevel = 0;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        switch (angerLevel)
        {
            case 0: customerSprite.sprite = happySprite; break;
            case 1: customerSprite.sprite = neutralSprite; break;
            case 2: customerSprite.sprite = angrySprite; break;
        }
    }

    public int GetScore()
    {
        return angerLevel switch
        {
            0 => 3,
            1 => 2,
            2 => 1,
            _ => 1
        };
    }


}
