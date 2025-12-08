using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip clickClip;

    public void PlayClick()
    {
        if (sfx && clickClip)
            sfx.PlayOneShot(clickClip);
    }

}
