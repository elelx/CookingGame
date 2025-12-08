using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour
{
    public string sceneName;    // set scene name in Inspector
    public Button loadButton;   // assign your button
    public GameObject loadingScreen;

    public Image targetLoadingImage;
    public Sprite[] loadingImages;

    void Start()
    {
        loadingScreen.SetActive(false);
        int ranNum = Random.Range(0, 2);
        targetLoadingImage.sprite = loadingImages[ranNum];
        loadButton.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }
}
