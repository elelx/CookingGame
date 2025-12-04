using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class CuttingAnim : MonoBehaviour
{
  
    public PressKeys mashGate;

    public Animator currentAnim;
    bool played;

    bool inCutState;

    MultiCutController parent;

    public void SetParentController(MultiCutController p, PressKeys gate)
    {
        parent = p;
        mashGate = gate;
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
        if (!collision.CompareTag("Knife"))
        {
            Debug.Log("Entered, but NOT knife: " + collision.name);
            return;
        }

        Debug.Log("Knife ENTERED: " + collision.name);

        currentAnim = GetComponentInChildren<Animator>();

        played = false;

        inCutState = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Knife")) return;

        if (currentAnim == null) return;
        TryPlayCut();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Knife")) return;

        Debug.Log("Knife EXIT: " + collision.name);

        if (currentAnim)
        {
            currentAnim.SetBool("IsCutting", false);
            currentAnim.speed = 0f;
        }

        currentAnim = null;

    }

    void TryPlayCut()
    {
        if (played || currentAnim == null) return;

        bool mouseHeld = Input.GetMouseButton(0);  // dragging
        bool gateOK = (mashGate == null) ? true : mashGate.canCut;
        bool shouldCut = mouseHeld && gateOK;

        if (shouldCut)
        {
            
            if (!inCutState)
            {
                currentAnim.SetBool("IsCutting", true);
                inCutState = true;
            }
            // resume 
            currentAnim.speed = 1f;
        }
        else
        {
            // pause 
            currentAnim.speed = 0f;
        }
    }

    public void StopCut()
    {
        if (currentAnim == null) return;

        Debug.Log("cut finished!");

        played = true;//  done

        currentAnim.SetBool("IsCutting", false);

        Collider2D col = currentAnim.GetComponent<Collider2D>();
        if (col) col.enabled = false;

        currentAnim = null;

        if (parent) parent.NotifyPieceFinished();
    }

    public void ResetCutPiece()
    {
        played = false;
        inCutState = false;

        Animator childAnim = GetComponentInChildren<Animator>();
        if (childAnim)
        {
            childAnim.Rebind();
            childAnim.Update(0f);
            childAnim.SetBool("IsCutting", false);
            childAnim.speed = 0f;
        }

        Collider2D col = GetComponentInChildren<Collider2D>();
        if (col)
            col.enabled = true;

        currentAnim = null;
    }

}
