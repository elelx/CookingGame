using UnityEngine;

public class SoupResultButtonRotation : MonoBehaviour
{
    public GameRotation rotationCheck;    // checks c2 & p5
    public SoupManager soupManager;       // checks if soup is completed

    public GameObject soupResultButton;   // the button prefab in scene

    void Update()
    {
        bool inCorrectPosition = rotationCheck.c2 && rotationCheck.p5;
        bool soupIsReady = soupManager.HasFinishedSoup();

        // Only enable Image when both true
        if (soupResultButton != null)
        {
            var img = soupResultButton.GetComponent<UnityEngine.UI.Image>();
            if (img != null)
                img.enabled = inCorrectPosition && soupIsReady;
        }
    }
}
