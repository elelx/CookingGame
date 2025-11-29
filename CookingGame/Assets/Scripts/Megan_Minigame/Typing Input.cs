using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TypingInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public TypingSubmit submitHandler;

    void Start() => ActivateInput();

    void Update()
    {
        if (!ManualBookUI.isManualOpen)
        {
            if (!inputField.isFocused) ActivateInput();
            
            //Press Enter to Submit Text
            if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
                submitHandler.SubmitText();
        }
    }

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
