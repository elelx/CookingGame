using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CutingBoardAnim : MonoBehaviour
{
    public Animator anim;
    public PressKeys mashGate;

    void Update()
    {
        if (!anim || !mashGate) return;

        anim.speed = mashGate.canCut ? 0f : 1f;
    }

    public bool IsBoardReady()
    {
        return mashGate != null && mashGate.canCut;
    }
}
