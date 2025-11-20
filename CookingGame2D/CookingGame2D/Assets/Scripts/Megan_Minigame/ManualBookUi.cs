using UnityEngine;
using UnityEngine.InputSystem;

public class ManualBookUI : MonoBehaviour
{
    [Header("UI Panel")]
    public GameObject manualPanel;

    [Header("Typing Input")]
    public TypingInput typingInput;  // drag your TypingInput object here in inspector

    [HideInInspector]
    public static bool isManualOpen = false;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            isManualOpen = !isManualOpen;
            manualPanel.SetActive(isManualOpen);

            if (typingInput != null)
            {
                if (isManualOpen)
                    typingInput.DisableInput();
                else
                    typingInput.EnableInput();
            }
        }
    }
}
