using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    public GameObject imageObject;  // The image GameObject to show/hide
    public Button toggleButton;     // The button you click

    bool isVisible = false;

    void Start()
    {
        if (toggleButton != null)
            toggleButton.onClick.AddListener(ToggleImage);

        // Start hidden (optional)
        imageObject.SetActive(false);
    }

    void ToggleImage()
    {
        isVisible = !isVisible;
        imageObject.SetActive(isVisible);
    }
}
