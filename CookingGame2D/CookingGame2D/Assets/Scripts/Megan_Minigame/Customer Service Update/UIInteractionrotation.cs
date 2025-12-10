using System.Collections.Generic;
using UnityEngine;

public class UIInteractionrotation : MonoBehaviour
{
    public GameRotation testGme;
    public bool isSceneOActive;

    [Header("UI Objects To Toggle")]
    public List<GameObject> uiObjects;

    void Start()
    {
        SetUI(true);
        testGme.c2 = true;
        testGme.p5 = true;
    }

    void Update()
    {
        CheckActivation();
    }

    void CheckActivation()
    {
        bool p1Ready = testGme.c2;
        bool p2Ready = testGme.p5;

        if (p1Ready && p2Ready)
        {
            if (!isSceneOActive)
            {
                isSceneOActive = true;
                SetUI(true);
            }
        }
        else
        {
            if (isSceneOActive)
            {
                isSceneOActive = false;
                SetUI(false);
            }
        }
    }

    void SetUI(bool state)
    {
        foreach (GameObject ui in uiObjects)
        {
            ui.SetActive(state);
        }
    }
}
