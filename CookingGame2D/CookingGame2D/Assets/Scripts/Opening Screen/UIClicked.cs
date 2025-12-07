using UnityEngine;
using UnityEngine.UI;

public class UIClicked : MonoBehaviour
{
    [Header("Sprites")]
    public Image targetImage;        // UI Image to swap sprite on
    public Sprite spriteOn;          // First sprite
    public Sprite spriteOff;         // Second sprite

    [Header("Audio")]
    public AudioClip clickSound;     // Plays when clicked
    public float volume = 1f;

    [Header("Settings")]
    public bool isOn = false;        // Current toggle state

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("SpriteToggleButton: No Button component found.");
            return;
        }

        if (targetImage == null)
            targetImage = GetComponent<Image>();

        // Apply initial sprite
        UpdateSprite();

        button.onClick.AddListener(ToggleSprite);
    }

    void ToggleSprite()
    {
        isOn = !isOn;
        UpdateSprite();

        // Play audio clip (no AudioSource needed on this object)
        if (clickSound != null)
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, volume);
    }

    void UpdateSprite()
    {
        if (targetImage != null)
        {
            targetImage.sprite = isOn ? spriteOn : spriteOff;
        }

        // NOTE: Animator will keep playing because we only change the sprite,
        // we DO NOT disable the object, change states, or disable Animator
    }
}
