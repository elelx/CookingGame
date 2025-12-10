using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneName;
    public Button loadButton;
    public GameObject loadingScreen;

    [Header("Loading Image")]
    public Image targetLoadingImage;
    public Sprite[] loadingImages;

    [Header("Sound")]
    public AudioSource sfxSource;    
    public AudioClip clickSound;     

    void Start()
    {
        loadingScreen.SetActive(false);

        int ranNum = Random.Range(0, loadingImages.Length);
        targetLoadingImage.sprite = loadingImages[ranNum];

        loadButton.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        // Play click sound
        if (sfxSource != null && clickSound != null)
            sfxSource.PlayOneShot(clickSound);

        // Activate loading screen
        loadingScreen.SetActive(true);

        // Load scene
        SceneManager.LoadScene(sceneName);
    }
}
