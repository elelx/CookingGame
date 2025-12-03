using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class FoodPrepRotation : MonoBehaviour
{

    public Camera cam;
    bool holding;

    public GameRotation testGme;
    public bool isSceneOActive;

    public List<GameObject> buttons;

    void Awake()
    {
        if (!cam) cam = Camera.main;
    }

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

        if (!isSceneOActive) return;

        if (Input.GetMouseButtonDown(0)) holding = true;
        if (Input.GetMouseButtonUp(0)) holding = false;

        if (holding)
        {
            Vector3 m = cam.ScreenToWorldPoint(Input.mousePosition);
            m.z = 0f;
            transform.position = m;
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
