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

    public bool c1;
    public bool c2;
    public bool c3;

    public bool p4;
    public bool p5;
    public bool p6;

    void Update()
    {
        MoveCamera1();
        
    }


    public void ResetCameras1()
    {
        c1 = false;
        c2 = false;
        c3 = false;
    }

   public void ResetCameras2()
    {
        p4 = false;
        p5 = false;
        p6 = false;
    }

    void Start()
    {
        StartCoroutine(MoveCam(camPos2, mainCam1));
        StartCoroutine(MoveCam(camPos5, mainCam2));
    }

    void CheckAnger()
    {
        BasicCustomerManager customerManager = Object.FindFirstObjectByType<BasicCustomerManager>(); //Grab Active Customer Profile Script

        if (c2 == false)
        {
            customerManager.rightScene = false;
        }
        else if (c2 == true)
        {
            customerManager.timerIsOn = true;
        }
    }

    //We should probably fix this later, maybe put the cams on a numbered list
    public void MoveCamera1()  //Move camera for keyboard player
    {
       
        if (Keyboard.current.downArrowKey.wasPressedThisFrame) //Move camera down based on previous position
        {
            if (mainCam1.transform.position.y == camPos1.transform.position.y)
            {
                StartCoroutine(MoveCam(camPos2, mainCam1));

                ResetCameras1();

                c2 = true;
                return;
            }
            else if (mainCam1.transform.position.y == camPos2.transform.position.y)
            {
                StartCoroutine(MoveCam(camPos3, mainCam1));

                ResetCameras1();
                c3 = true;
                return;

            }
            
        }
        else if (Keyboard.current.upArrowKey.wasPressedThisFrame) //Move camera up based on previous position
        {
            if (mainCam1.transform.position.y == camPos2.transform.position.y)
            {
                StartCoroutine(MoveCam(camPos1, mainCam1));

                ResetCameras1();
                c1 = true;
                return;
            }
            else if (mainCam1.transform.position.y == camPos3.transform.position.y)
            {
                StartCoroutine(MoveCam(camPos2, mainCam1));

                ResetCameras1();
                c2 = true;
                return;
            }

        }
    }

    public void MoveCamera2Down() //Move camera down based on previous position
    {
        
        if (mainCam2.transform.position.y == camPos4.transform.position.y)
        {
            StartCoroutine(MoveCam(camPos5, mainCam2));

            ResetCameras2();
            p5 = true;
                return;
        }
        else if (mainCam2.transform.position.y == camPos5.transform.position.y)
        {
            StartCoroutine(MoveCam(camPos6, mainCam2));

            ResetCameras2();
            p6 = true;
            return;
        }
        else
        {
            StartCoroutine(MoveCam(camPos4, mainCam2));

            ResetCameras2();
            p4 = true;
            return;
        }
    }

    public void MoveCamera2Up() //Move camera up based on previous position
    {
        if (mainCam2.transform.position.y == camPos5.transform.position.y)
        {
            StartCoroutine(MoveCam(camPos4, mainCam2));

            ResetCameras2();

            p4 = true;
            return;
        }
        else if (mainCam2.transform.position.y == camPos6.transform.position.y)
        {
            StartCoroutine(MoveCam(camPos5, mainCam2));

            ResetCameras2();
            p5 = true;
                return;
        }
        else
        {
            StartCoroutine(MoveCam(camPos6, mainCam2));

            ResetCameras2();
            p6 = true;
            return;
        }
    }

    IEnumerator MoveCam(Transform targetCamNum, GameObject cameraNum)
    {
        CheckAnger();

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
