using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public GameObject Door;

    public Animator DoorT;
    //public string animName;

    public int mouseClickNeeded = 10;
    private int MouseClickCount = 0;

    public bool mousePressed = false;

    public float resetTime = 2.0f;
    private float resetTimer = 0f;
    private Camera cam;

    public bool mouseDone = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        PlayTwoMouse();
    }

    public void PlayTwoMouse()
    {
        Debug.Log("play2 is being called");
        resetTimer += Time.deltaTime;


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left mouse clicked");

            Vector2 mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("Clicked on the DOOR!");

                resetTimer = 0f;
                MouseClickCount+=1;

                Debug.Log("lick Count = " + MouseClickCount);

                DoorT.SetTrigger("PlayMash");

                if (MouseClickCount >= mouseClickNeeded)
                {
                    DoorT.SetBool("FullyOpen", true);
                    mouseDone = true;
                    Debug.Log("DOOR FULLY OPEN!");
                }
            }
            else
            {
                Debug.Log("You clicked, but NOT on the door.");
            }
        }
        if (resetTimer > resetTime)
        {
            MouseClickCount = 0;

            DoorT.SetBool("FullyOpen", false);

            Debug.Log("Mash reset");
        }
    }
}
