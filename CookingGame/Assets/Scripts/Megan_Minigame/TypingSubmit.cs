using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TypingSubmit : MonoBehaviour
{
    public TMP_InputField inputField;
    public CustomerDialogueManager dialogueManager;

    void Start() => inputField?.ActivateInputField();

    public void SubmitText()
    {
        if (inputField == null || dialogueManager == null) return; //If input field and customer dialoge manager script is null, Return

        string typed = inputField.text.ToLower().Trim(); //Log Text
        inputField.text = "";

        if (string.IsNullOrEmpty(typed))
        {
            inputField.ActivateInputField();
            return;
        }

        dialogueManager.CheckAnswer(typed); // Check answer in customer dialoge manager (returns bool but we don't need to store)
        inputField.ActivateInputField();
    }
}
