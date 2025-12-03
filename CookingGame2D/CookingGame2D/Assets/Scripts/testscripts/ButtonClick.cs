using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;


public class ButtonClick : MonoBehaviour
{

    public GameRotation testGme;
    public bool isSceneOActive;


    public List<GameObject> buttons; // multiple buttons


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetButtons(false);
    }

    // Update is called once per frame
    void Update()
    {
        onScene1();
    }

    public void onScene1()
    {
        //Debug.Log("hello");

        bool p1Ready = testGme.c2;
        bool p2Ready = testGme.p5;

        if (p1Ready && p2Ready)
        {
            isSceneOActive = true;
            SetButtons(true);
            //Debug.Log("you can press me");
           
        }
        else
        {
            //Debug.Log("get on the same page");
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

