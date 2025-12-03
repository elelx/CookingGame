using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class FoodPrepRotation : MonoBehaviour
{

    public GameRotation testGme;
    public bool isSceneOActive;

    public List<GameObject> buttons;


    void Start()
    {
        SetButtons(false);
    }

    void Update()
    {
        onFoodPrep();
    }

    public void onFoodPrep()
    {
        bool p1Ready = testGme.c1;
        bool p2Ready = testGme.p4;

        if (p1Ready && p2Ready)
        {
            if (!isSceneOActive)
            {
                isSceneOActive = true;
                SetButtons(true);
            }
        }


        else
        {
            isSceneOActive = false;
            SetButtons(false);
        }
     
    }

    void SetButtons(bool active)
    {
        foreach (GameObject b in buttons)
        {
            b.SetActive(active);
        }
    }
}
