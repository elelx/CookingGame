using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;


public class Door1 : MonoBehaviour
{

    public GameObject Door;

    public Animator DoorO;
    //public string animName;

    public int mashNeeded = 10;     
    private int mashCount = 0;

    public bool aPressed = false;

    public float resetTime = 2.0f;    
    private float resetTimer = 0f;
    public bool DoorDone = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayOneMash();
    }

    public void PlayOneMash()
    {
        Debug.Log("PlayOneMash is being called");
        resetTimer += Time.deltaTime;

       
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log("A was pressed");
            resetTimer = 0f;
 
            mashCount+=1;

            Debug.Log("Mash! Count = " + mashCount);

          
            DoorO.SetTrigger("PlayMash");

            if (mashCount >= mashNeeded)
            {
                DoorO.SetBool("FullyOpen", true);
                DoorDone = true;
                Debug.Log("Door fully opened!");
            }
        }
        if (resetTimer > resetTime)
        {
            mashCount = 0;
    
            DoorO.SetBool("FullyOpen", false);

            Debug.Log("Mash reset");
        }
    }
}

