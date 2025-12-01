using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;


public class ButtonClick : MonoBehaviour
{

    public GameRotation testGme;
    public bool isSceneOActive;

    public GameObject canPlaybutton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canPlaybutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        onScene1();
    }

    public void onScene1()
    {
        //Debug.Log("hello");

        bool p1Ready = testGme.c1;
        bool p2Ready = testGme.p4;

        if (p1Ready && p2Ready)
        {
            isSceneOActive = true;
            canPlaybutton.SetActive(true);
            //Debug.Log("you can press me");
           
        }
        else
        {
            //Debug.Log("get on the same page");
            isSceneOActive = false;
            canPlaybutton.SetActive(false);
        }
    }

    public void SceneOPlayable()
    {
        
      Debug.Log("You clicked me to play");

        
 
    }
}

