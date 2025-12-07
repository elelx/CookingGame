using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    public Sprite spriteOn;      // Sprite when ON
    public Sprite spriteOff;     // Sprite when OFF
    public AudioClip clickSound; // Optional sound

    private SpriteRenderer sr;
    private bool isOn = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("FlipSprite: No SpriteRenderer found!");
            return;
        }

        // Start with OFF sprite
        sr.sprite = spriteOff;
    }

    void OnMouseDown()
    {
        Toggle();
    }

    void Toggle()
    {
        // toggle state
        isOn = !isOn;

        // sound
        if (clickSound != null)
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);

        // sprite change
        if (isOn)
            sr.sprite = spriteOn;
        else
            sr.sprite = spriteOff;
    }
}
