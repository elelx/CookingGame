using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class GameRotation : MonoBehaviour
{
    [Header("Camera Group 1")]
    public GameObject mainCam1;
    public Transform camPos1;
    public Transform camPos2;
    public Transform camPos3;

    [Header("Camera Group 2")]
    public GameObject mainCam2;
    public Transform camPos4;
    public Transform camPos5;
    public Transform camPos6;

    public float timer = 0.5f;

    void Update()
    {
        MoveCamera1();
    }

    //We should probably fix this later, maybe put the cams on a numbered list
    void MoveCamera1()  //Move camera for keyboard player
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame) //Move camera down based on previous position
        {
            if (mainCam1.transform.position.y == camPos1.transform.position.y)
            {
                StartCoroutine(MoveCam(camPos2, mainCam1));
            }
            else if (mainCam1.transform.position.y == camPos2.transform.position.y)
            {
                StartCoroutine(MoveCam(camPos3, mainCam1));
            }
            
        }
        else if (Keyboard.current.upArrowKey.wasPressedThisFrame) //Move camera up based on previous position
        {
            if (mainCam1.transform.position.y == camPos2.transform.position.y)
            {
                StartCoroutine(MoveCam(camPos1, mainCam1));
            }
            else if (mainCam1.transform.position.y == camPos3.transform.position.y)
            {
                StartCoroutine(MoveCam(camPos2, mainCam1));
            }

        }
    }

    public void MoveCamera2Down() //Move camera down based on previous position
    {
        if (mainCam2.transform.position.y == camPos4.transform.position.y)
        {
            StartCoroutine(MoveCam(camPos5, mainCam2));
        }
        else if (mainCam2.transform.position.y == camPos5.transform.position.y)
        {
            StartCoroutine(MoveCam(camPos6, mainCam2));
        }
        else
        {
            StartCoroutine(MoveCam(camPos4, mainCam2));
        }
    }

    public void MoveCamera2Up() //Move camera up based on previous position
    {
        if (mainCam2.transform.position.y == camPos5.transform.position.y)
        {
            StartCoroutine(MoveCam(camPos4, mainCam2));
        }
        else if (mainCam2.transform.position.y == camPos6.transform.position.y)
        {
            StartCoroutine(MoveCam(camPos5, mainCam2));
        }
        else
        {
            StartCoroutine(MoveCam(camPos6, mainCam2));
        }
    }

    IEnumerator MoveCam(Transform targetCamNum, GameObject cameraNum)
    {
        Vector3 startPos = new Vector3(cameraNum.transform.position.x, cameraNum.transform.position.y, cameraNum.transform.position.z);
        Vector3 endPos = new Vector3(targetCamNum.position.x, targetCamNum.position.y, startPos.z);

        float elapsed = 0f;
        while (elapsed < timer)
        {
            elapsed += Time.deltaTime;
            cameraNum.transform.position = Vector3.Lerp(startPos, endPos, elapsed / timer);
            yield return null;
        }

        cameraNum.transform.position = endPos; // Set Final Position
        elapsed = 0f;
    }
}
