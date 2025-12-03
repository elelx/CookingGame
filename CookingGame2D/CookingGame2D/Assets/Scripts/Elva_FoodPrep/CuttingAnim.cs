using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class CuttingAnim : MonoBehaviour
{
    public Animator anim;           
    public string cutBool = "IsCutting"; 
    public PressKeys mashGate;

    bool played;

    bool inCutState;

    void Awake()
    {
        if (!anim) anim = GetComponent<Animator>();
        //if (anim) anim.speed = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (played) return;
        Debug.Log("Entered cut: " + collision.name);


        TryPlayCut();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
       
        TryPlayCut();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left cut zone: " + collision.name);
        if (anim) anim.SetBool(cutBool, false); // stop anim 
        if (anim) anim.speed = 0f;
    }

    void TryPlayCut()
    {
        bool mouseHeld = Input.GetMouseButton(0);  // dragging
        bool gateOK = (mashGate == null) ? true : mashGate.canCut;
        bool shouldCut = mouseHeld && gateOK;

        if (!anim) return;

        if (shouldCut)
        {
            
            if (!inCutState)
            {
                anim.SetBool(cutBool, true);
                inCutState = true;
            }
            // resume 
            anim.speed = 1f;
        }
        else
        {
            // pause 
            anim.speed = 0f;
        }
    }

    public void StopCut()
    {
        Debug.Log("Cut animation finished!");
        played = true;                //  done
        if (anim) anim.SetBool(cutBool, false); // stop

        var col = GetComponent<Collider2D>();
        if (col) col.enabled = false;
    }
}
