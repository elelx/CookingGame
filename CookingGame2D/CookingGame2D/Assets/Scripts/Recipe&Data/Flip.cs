using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    public AudioClip clickSound; // Optional sound

    private bool isOn = false;

    public GameObject InformationScreen;

    public void TurnoffScreens()
    {
        InformationScreen.SetActive(false);
    }

    void OnMouseDown()
    {
        Toggle();
    }

    void Toggle()
    {
        // sound
        if (clickSound != null)
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);

        if (RecipeDataScreens.PageIsOpened == false)
        {
            // toggle state
            isOn = true;
            RecipeDataScreens.PageIsOpened = true;

            // State change
            InformationScreen.SetActive(true);
        }
    }
}
