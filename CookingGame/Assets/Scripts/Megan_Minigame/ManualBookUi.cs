using UnityEngine;
using UnityEngine.InputSystem;

public class ManualBookUI : MonoBehaviour
{
    [Header("UI Panel")]
    public GameObject manualPanel;

    [Header("Typing Input")]
    public TypingInput typingInput;  // Typing Input Object

    [HideInInspector]
    public static bool isManualOpen = false;

    void Update()
    {
        //If player presses 1, Open Manuel

        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            isManualOpen = !isManualOpen;
            manualPanel.SetActive(isManualOpen);

            Debug.Log(isManualOpen ? "Open" : "Close");

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
