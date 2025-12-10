using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class CuttingAnim : MonoBehaviour
{
    public CutingBoardAnim boardGate;

    public AudioSource sfx;
    public AudioClip[] finishClips;

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



    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Knife")) return;
        if (played) return;
        if (mashGate == null) return;

        Cut knife = collision.GetComponent<Cut>();
        if (knife == null) return;

        bool gateOK = mashGate.canCut;
        bool knifeMoving = knife.isMoving;
        bool boardOK = boardGate == null || boardGate.IsBoardReady();


        if (gateOK && knifeMoving)
        {
            knife.StartCutSound();
        }
        else
        {
            knife.StopCutSound();
        }

        if (!gateOK || !knifeMoving || !boardOK)
        {
            knife.StopCutSound();

            if (currentAnim)
            {
                currentAnim.SetBool("IsCutting", false);
                currentAnim.speed = 0f;
            }
            return;
        }

        if (currentAnim == null)
            currentAnim = GetComponentInChildren<Animator>();

        if (currentAnim == null) return;

        currentAnim.SetBool("IsCutting", true);
        currentAnim.speed = 1f;
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

        Cut knife = collision.GetComponent<Cut>();
        if (knife)
            knife.StopCutSound();


        currentAnim = null;

    }


    public void StopCut()
    {
        if (finishClips != null && finishClips.Length > 0 && sfx)
        {
            AudioClip clip = finishClips[Random.Range(0, finishClips.Length)];
            sfx.PlayOneShot(clip);
        }


        Debug.Log("cut finished!");

        played = true;//  done

        if (currentAnim)
        {
            currentAnim.SetBool("IsCutting", false);
            currentAnim.speed = 0f;
        }

        if (parent)
            parent.NotifyPieceFinished();
    
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
