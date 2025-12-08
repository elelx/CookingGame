using UnityEngine;
using UnityEngine.UI;

public class SoupResultButtonRotation : MonoBehaviour
{
    public GameRotation rotationCheck;    // checks c2 & p5
    public SoupManager soupManager;       // checks if soup is completed

    public GameObject soupResultButton;   // the button prefab in scene

    public bool inCorrectPosition = false;
    public bool soupIsReady = false;
    private Button soupResultButtonUI;

    private void Start()
    {
        soupResultButtonUI = soupResultButton.GetComponent<Button>();

    }
    void Update()
    {
        inCorrectPosition = rotationCheck.c2 && rotationCheck.p5;
        soupIsReady = soupManager.HasFinishedSoup();

        // Only enable Image when both true
        if (soupResultButton != null)
        {
            var img = soupResultButton.GetComponent<UnityEngine.UI.Image>();
            if (img != null)
                img.enabled = inCorrectPosition && soupIsReady;
                soupResultButtonUI.interactable = inCorrectPosition && soupIsReady;
        }
    }
}
