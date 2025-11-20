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
        if (inputField == null || dialogueManager == null) return;

        string typed = inputField.text.ToLower().Trim();
        inputField.text = "";

        if (string.IsNullOrEmpty(typed))
        {
            inputField.ActivateInputField();
            return;
        }

        dialogueManager.CheckAnswer(typed); // returns bool but we don't need to store
        inputField.ActivateInputField();
    }
}
