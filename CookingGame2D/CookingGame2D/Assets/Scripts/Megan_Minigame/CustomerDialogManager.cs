using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class CustomerDialogueManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text customerText;

    [Header("Customer Sprite")]
    [SerializeField] private SpriteRenderer customerSprite;

    [Header("Emotion Sprites")]
    [SerializeField] private Sprite happySprite;
    [SerializeField] private Sprite neutralSprite;
    [SerializeField] private Sprite angrySprite;

    [Header("Dialogue Settings")]
    [SerializeField] private string[] customerLines;
    [SerializeField] private string[] correctReplies;
    [SerializeField] private float answerTimeLimit = 10f;

    [Header("Service Points")]
    [SerializeField] private ServicePoints servicePoints;

    // Internal state
    private int angerLevel = 0; // 0=happy, 1=neutral, 2=angry
    private int currentLineIndex = 0;
    private float timer;

    private void Start()
    {
        if (customerText == null)
            Debug.LogWarning("CustomerText not assigned in Inspector!");

        if (customerSprite == null)
            customerSprite = GetComponent<SpriteRenderer>();

        ResetDialogue();
    }

    private void Update()
    {
        // timer for automatic anger increase
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            IncreaseAnger();
            ResetTimer();
        }
    }

    // ===================== Dialogue =====================

    public bool CheckAnswer(string typed)
    {
        typed = typed.ToLower().Trim();

        if (typed == correctReplies[currentLineIndex])
        {
            // correct answer
            ResetEmotion();
            NextDialogue();
            return true; // correct
        }
        else
        {
            // wrong answer increases anger
            IncreaseAnger();
            return false; // wrong
        }
    }

    public void NextDialogue()
    {
        currentLineIndex++;
        if (currentLineIndex >= customerLines.Length)
            currentLineIndex = 0; // loop back to first line or stop here

        ShowCurrentDialogue();
        ResetTimer();
    }

    public void ResetDialogue()
    {
        currentLineIndex = 0;
        ShowCurrentDialogue();
        ResetEmotion();
        ResetTimer();
    }

    public void ShowCurrentDialogue()
    {
        if (customerText != null)
            customerText.text = customerLines[currentLineIndex];
    }

    private void ResetTimer()
    {
        timer = answerTimeLimit;
    }

    // ===================== Emotion / Sprite =====================

    public void IncreaseAnger()
    {
        angerLevel++;
        if (angerLevel > 2) angerLevel = 2;

        UpdateSprite();
    }

    public void ResetEmotion()
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

    public int GetCustomerScore()
    {
        switch (angerLevel)
        {
            case 0: return 3;
            case 1: return 2;
            case 2: return 1;
            default: return 0;
        }
    }

    // ===================== Food Delivery =====================

    private void OnTriggerEnter2D(Collider2D other)
    {
        CookableFood food = other.GetComponent<CookableFood>();
        if (food != null)
        {
            // give points based on current emotion
            if (servicePoints != null)
                servicePoints.AddPoints(GetCustomerScore());

            // destroy the food
            Destroy(food.gameObject);

            // reset emotion and advance dialogue
            ResetEmotion();
            NextDialogue();
        }
    }
}
