using UnityEngine;

public class RecipeDataScreens : MonoBehaviour
{
    public static bool PageIsOpened;

    public AudioClip clickSound; // Optional sound

    private bool isOn = false;

    void OnMouseDown()
    {
        Toggle();
    }

    void Toggle()
    {
        // toggle state
        isOn = false;
        PageIsOpened = false;

        // sound
        if (clickSound != null)
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);

        // State change
        gameObject.SetActive(false);
    }
}
