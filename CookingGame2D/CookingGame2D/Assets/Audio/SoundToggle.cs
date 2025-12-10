using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    public AudioSource backgroundMusic;     // Background music
    public Button volumeButton;             // UI Button
    public AudioSource sfxSource;           // AudioSource to play click sound
    public AudioClip clickSound;            // The click sound clip

    private bool isMuted = false;

    void Start()
    {
        volumeButton.onClick.AddListener(ToggleVolume);
    }

    void ToggleVolume()
    {
        // Play click SFX
        if (sfxSource != null && clickSound != null)
            sfxSource.PlayOneShot(clickSound);

        // Toggle mute
        isMuted = !isMuted;
        backgroundMusic.volume = isMuted ? 0f : 1f;

        Debug.Log("Music Volume: " + backgroundMusic.volume);
    }
}
