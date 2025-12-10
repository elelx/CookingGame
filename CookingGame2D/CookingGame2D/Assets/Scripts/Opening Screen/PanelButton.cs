using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    [Header("Credits Movement")]
    public Transform posTargetStart;
    public Transform posTargetEnd;
    public float smoothTime = 0.7f;

    [Header("UI")]
    public GameObject imageObject;     // The image to show/hide
    public Button toggleButton;        // Button to click

    [Header("Sound")]
    public AudioSource sfxSource;      // AudioSource for click sound
    public AudioClip clickSound;       // The click sound

    private bool isVisible = false;

    void Start()
    {
        if (toggleButton != null)
            toggleButton.onClick.AddListener(ToggleImage);
    }

    public void ToggleImage()
    {
        isVisible = !isVisible;

        // Play click SFX only when hiding (you can change this if needed)
        if (!isVisible)
        {
            if (sfxSource != null && clickSound != null)
                sfxSource.PlayOneShot(clickSound);

            StartCoroutine(MoveCreditsDown());
        }
        else
        {
            StartCoroutine(MoveCreditsUp());
            if (sfxSource != null && clickSound != null)
                sfxSource.PlayOneShot(clickSound);
        }
    }

    IEnumerator MoveCreditsDown()
    {
        Vector3 startPos = imageObject.transform.position;
        Vector3 endPos = new Vector3(posTargetEnd.position.x, posTargetEnd.position.y, startPos.z);

        float elapsed = 0f;
        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / smoothTime;

            imageObject.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        imageObject.transform.position = endPos;
    }

    IEnumerator MoveCreditsUp()
    {
        Vector3 startPos = imageObject.transform.position;
        Vector3 endPos = new Vector3(posTargetStart.position.x, posTargetStart.position.y, startPos.z);

        float elapsed = 0f;
        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / smoothTime;

            imageObject.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        imageObject.transform.position = endPos;
    }
}
