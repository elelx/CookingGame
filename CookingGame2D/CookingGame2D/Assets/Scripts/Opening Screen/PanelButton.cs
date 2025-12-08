using System.Collections;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    [Header("Credits")]
    public Transform posTargetStart;
    public Transform posTargetEnd;
    public float smoothTime = 0.7f;

    public GameObject imageObject;  // The image GameObject to show/hide
    public Button toggleButton;     // The button you click

    bool isVisible = false;

    void Start()
    {
        if (toggleButton != null)
            toggleButton.onClick.AddListener(ToggleImage);

    }

    public void ToggleImage()
    {
        isVisible = !isVisible;

        if (isVisible == false)
        {
            StartCoroutine(MoveCreditsDown());
        }
        else if (isVisible == true)
        {
            StartCoroutine(MoveCreditsUp());
        }
    }
    IEnumerator MoveCreditsDown()
    {
        //Set Positions
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
        //Set Positions
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
