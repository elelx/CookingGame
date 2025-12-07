using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour
{
    public string sceneName;    // set scene name in Inspector
    public Button loadButton;   // assign your button

    void Start()
    {
        loadButton.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
