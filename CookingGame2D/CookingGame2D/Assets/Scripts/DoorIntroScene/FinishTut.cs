using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
public class FinishTut : MonoBehaviour
{
    public Door1 Player1;
    public Door2 Player2;

    public bool Door1Finished = false;
    public bool Door2Finished = false;

    public GameObject tutorialFinishedUI;

    private bool finishedShown = false;

    public GameObject uNeed2WorkTGHUI;

    private bool friendshoip = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (tutorialFinishedUI != null)
            tutorialFinishedUI.SetActive(false);

        if (uNeed2WorkTGHUI != null)
            uNeed2WorkTGHUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
 
        CheckProgress();
    }

    void CheckProgress()
    {
        if (finishedShown) return;

        if (Player1.DoorDone && Player2.mouseDone)
        {
            finishedShown = true;

            tutorialFinishedUI.SetActive(true);
            uNeed2WorkTGHUI.SetActive(false);

            Debug.Log("Tutorial COMPLE!");
            return;
        }

        if (Player1.DoorDone && !Player2.mouseDone)
        {
            uNeed2WorkTGHUI.SetActive(true);

            return;
        }

        if (!Player1.DoorDone && Player2.mouseDone)
        {
            uNeed2WorkTGHUI.SetActive(true);

            return;
        }

        uNeed2WorkTGHUI.SetActive(false);
    }

    }
