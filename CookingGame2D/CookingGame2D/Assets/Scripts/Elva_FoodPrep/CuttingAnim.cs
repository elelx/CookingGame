using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class CuttingAnim : MonoBehaviour
{
    public PressKeys mashGate;
    public CutingBoardAnim boardGate;

    public AudioSource sfx;
    public AudioClip[] finishClips;

    MultiCutController parent;

    int hitCount = 0;
    int requiredHits;
    bool finished = false;

    Animator anim;
    Collider2D col;

    public void SetParentController(MultiCutController p, PressKeys gate)
    {
        parent = p;
        mashGate = gate;
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();   // NEW
        col = GetComponent<Collider2D>();

        requiredHits = Random.Range(5, 10);
        Debug.Log($"[{name}] REQUIRED HITS = {requiredHits}");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Knife")) return;

        Debug.Log($"[{name}] TRIGGER STAY WITH KNIFE");

        if (finished)
            return;

        // ---- GATE CHECKS ----
        bool gateOK = mashGate != null && mashGate.canCut;
        bool boardOK = boardGate == null || boardGate.IsBoardReady();

        Cut knife = collision.GetComponent<Cut>();
        if (knife == null) return;

        bool knifeMoving = knife.isMoving;

        Debug.Log($"[{name}] mashGate.canCut = {gateOK}");
        Debug.Log($"[{name}] boardOK = {boardOK}");
        Debug.Log($"[{name}] knifeMoving = {knifeMoving}");

        if (!gateOK || !boardOK || !knifeMoving)
        {
            Debug.Log($"[{name}] ❌ BLOCKED — cannot cut this frame");
            return;
        }

        // ---- VALID HIT ----
        hitCount++;
        Debug.Log($"[{name}] HIT! Count = {hitCount} / {requiredHits}");

        // PLAY ANIMATION HERE
        if (anim)
        {
            anim.SetTrigger("Cut");
        }

        if (hitCount >= requiredHits)
        {
            Debug.Log($"[{name}] FINISHED CUTTING!!!");
            FinishCut();
        }
    }

    void FinishCut()
    {
        finished = true;

        if (sfx && finishClips.Length > 0)
            sfx.PlayOneShot(finishClips[Random.Range(0, finishClips.Length)]);

        if (col) col.enabled = false;

        parent?.NotifyPieceFinished();
    }

    public void ResetCutPiece()
    {
        finished = false;
        hitCount = 0;
        requiredHits = Random.Range(2, 6);

        if (col) col.enabled = true;

        if (anim)
        {
            anim.Rebind();
            anim.Update(0f);
        }
    }
}


//public CutingBoardAnim boardGate;

//public AudioSource sfx;
//public AudioClip[] finishClips;

//public PressKeys mashGate;

//public Animator currentAnim;
//bool played;

//bool inCutState;

//MultiCutController parent;

//public void SetParentController(MultiCutController p, PressKeys gate)
//{
//    parent = p;
//    mashGate = gate;
//}


//// Start is called before the first frame update
//void Start()
//{

//}

//// Update is called once per frame
//void Update()
//{


//}



//void OnTriggerStay2D(Collider2D collision)
//{
//    if (!collision.CompareTag("Knife")) return;
//    if (played) return;
//    if (mashGate == null) return;

//    Cut knife = collision.GetComponent<Cut>();
//    if (knife == null) return;

//    bool gateOK = mashGate.canCut;
//    bool knifeMoving = knife.isMoving;
//    bool boardOK = boardGate == null || boardGate.IsBoardReady();


//    if (gateOK && knifeMoving)
//    {
//        knife.StartCutSound();
//    }
//    else
//    {
//        knife.StopCutSound();
//    }

//    if (!gateOK || !knifeMoving || !boardOK)
//    {
//        knife.StopCutSound();

//        if (currentAnim)
//        {
//            currentAnim.SetBool("IsCutting", false);
//            currentAnim.speed = 0f;
//        }
//        return;
//    }

//    if (currentAnim == null)
//        currentAnim = GetComponentInChildren<Animator>();

//    if (currentAnim == null) return;

//    currentAnim.SetBool("IsCutting", true);
//    currentAnim.speed = 1f;
//}



//void OnTriggerExit2D(Collider2D collision)
//{
//    if (!collision.CompareTag("Knife")) return;

//    Debug.Log("Knife EXIT: " + collision.name);

//    if (currentAnim)
//    {
//        currentAnim.SetBool("IsCutting", false);
//        currentAnim.speed = 0f;
//    }

//    Cut knife = collision.GetComponent<Cut>();
//    if (knife)
//        knife.StopCutSound();


//    currentAnim = null;

//}


//public void StopCut()
//{
//    played = true;

//    if (finishClips.Length > 0 && sfx)
//        sfx.PlayOneShot(finishClips[Random.Range(0, finishClips.Length)]);

//    if (currentAnim)
//    {
//        currentAnim.SetBool("IsCutting", false);
//        currentAnim.speed = 0;
//    }

//    parent?.NotifyPieceFinished();
//}

//public void ResetCutPiece()
//{
//    played = false;
//    inCutState = false;

//    Animator childAnim = GetComponentInChildren<Animator>();
//    if (childAnim)
//    {
//        childAnim.Rebind();
//        childAnim.Update(0f);
//        childAnim.SetBool("IsCutting", false);
//        childAnim.speed = 0f;
//    }

//    Collider2D col = GetComponentInChildren<Collider2D>();
//    if (col)
//        col.enabled = true;

//    currentAnim = null;
//}


