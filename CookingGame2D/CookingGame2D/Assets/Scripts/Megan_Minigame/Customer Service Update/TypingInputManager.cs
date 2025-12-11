using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TypingInputManager : MonoBehaviour
{
    public TMP_InputField inputField;
    private BasicCustomerManager dialogueManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueManager = GetComponent<BasicCustomerManager>();
        inputField?.ActivateInputField();
        ActivateInput();
    }

    //TEXT SUBMISSION

    // Update is called once per frame
    void Update()
    {
        if (!inputField.isFocused) ActivateInput(); //Activate Input

        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
            SubmitText(); //Submit
    }
    public void SubmitText()
    {
        string typed = inputField.text.ToLower().Trim();
        inputField.text = "";

        if (string.IsNullOrEmpty(typed))
        {
            inputField.ActivateInputField();
            return;
        }

        dialogueManager.CheckTypedAnswer(typed);

        // Keep typing field active for next customer
        inputField.ActivateInputField();
    }

    //ACTIVIVATE AND DECATIVATE INPUT FIELD
    public void ActivateInput()
    {
        inputField.interactable = true;
        inputField.ActivateInputField();
    }

    public void DeactivateInput()
    {
        inputField.interactable = false;
        inputField.DeactivateInputField();
    }

    public void DisableInput() => DeactivateInput();
    public void EnableInput() => ActivateInput();
}
