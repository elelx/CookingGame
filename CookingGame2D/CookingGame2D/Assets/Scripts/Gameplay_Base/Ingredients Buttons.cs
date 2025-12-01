using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;


public class IngredientsButtons : MonoBehaviour
{

    public GameRotation testGame;
    public bool isSceneTActive;

    public GameObject canPlaybutton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canPlaybutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        onScene2();
    }


    public void onScene2()
    {
        //Debug.Log("hello");

        bool p1Ready = testGame.c2;
        bool p2Ready = testGame.p5;

        if (p1Ready && p2Ready)
        {
            isSceneTActive = true;
            canPlaybutton.SetActive(true);
            //Debug.Log("you can press me #2");

        }
        else
        {
            //Debug.Log("get on the same page#2");
            isSceneTActive = false;
            canPlaybutton.SetActive(false);
        }
    }

    public void SceneOPlayable()
    {

        Debug.Log("You clicked me to play");



    }
}

