using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class RecipeDataRotation : MonoBehaviour
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
        RecepData();
    }

    public void RecepData()
    {
        bool p1Ready = testGme.c3;
        bool p2Ready = testGme.p6;

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
