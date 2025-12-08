using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PressKeys : MonoBehaviour
{
    public GameRotation testGme;
    public bool isSceneOActive;
    public bool canCut;


    //public bool FirstCond;
    //public bool SecondCond;
    //public bool AllCondMet;


    public float pressLifetime = 0.45f;

    public KeyCode[] keys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.J, KeyCode.K, KeyCode.L };//, KeyCode.J, KeyCode.K, KeyCode.L

    // public Text statusText;

    float timeA;
    float timeS;
    float timeD;
    float timeJ;
    float timeK;
    float timeL;

    // Start is called before the first frame update
    void Start()
    {
        canCut = false;
        ResetKeys();
    }

    // Update is called once per frame
    void Update()
    {
        if (testGme.c1 && testGme.p4)
        {
            isSceneOActive = true;
            HoldingPan();
        }
        else
        {
            isSceneOActive = false;
            canCut = false;
        }
    }

    void HoldingPan()
    {
        float now = Time.time;

        if (Input.GetKeyDown(KeyCode.A))
        {
            timeA = now;
            Debug.Log("Pressed A");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            timeS = now;
            Debug.Log("Pressed S");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            timeD = now;
            Debug.Log("Pressed D");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            timeJ = now;
            Debug.Log("Pressed J");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            timeK = now;
            Debug.Log("Pressed K");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            timeL = now;
            Debug.Log("Pressed L");
        }


        // check if each key was pressed

        bool aHot = now - timeA <= pressLifetime;
        bool sHot = now - timeS <= pressLifetime;
        bool dHot = now - timeD <= pressLifetime;

        bool jHot = now - timeJ <= pressLifetime;
        bool kHot = now - timeK <= pressLifetime;
        bool lHot = now - timeL <= pressLifetime;

        // left and right side checks

        bool leftHand = aHot && sHot && dHot;
        bool rightHand = jHot && kHot && lHot;

        
        canCut = leftHand && rightHand;

    }

    void ResetKeys()
    {
        timeA = timeS = timeD = timeJ = timeK = timeL = -999f;

    }
}
