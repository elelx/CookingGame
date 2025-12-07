using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;

public class ShelfScript : MonoBehaviour
{
    public RectTransform shelfVisual;
    public float slideDistance = 50f;

    [Header("Audio Settings")]
    public AudioClip toggleSound;
    public float playDelay = 0.05f;
    public float fadeInTime = 0.1f;

    private AudioSource audioSource;
    private Vector3 originalPosition;
    private bool isSlid = false;

    void Start()
    {
        if (shelfVisual == null)
        {
            Debug.LogError("ShelfScript: No shelfVisual assigned!");
            return;
        }

        // Audio
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.volume = 1f;

        originalPosition = shelfVisual.localPosition;
    }

    void Update()
    {
        // Press Q to get shelf
        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            ToggleSlide();
        }
    }

    void ToggleSlide()
    {
        // Play sound
        if (toggleSound != null)
            StartCoroutine(PlaySoundDelayed(toggleSound, playDelay, fadeInTime));

        // Slide motion
        if (isSlid)
        {
            shelfVisual.localPosition = originalPosition;
            isSlid = false;
        }
        else
        {
            shelfVisual.localPosition = originalPosition + Vector3.right * slideDistance;
            isSlid = true;
        }
    }

    private IEnumerator PlaySoundDelayed(AudioClip clip, float delay, float fadeDuration)
    {
        yield return new WaitForSeconds(delay);

        audioSource.clip = clip;
        audioSource.volume = 0f;
        audioSource.Play();

        if (fadeDuration > 0)
        {
            float t = 0f;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(0f, 1f, t / fadeDuration);
                yield return null;
            }
        }

        audioSource.volume = 1f;
    }
}
