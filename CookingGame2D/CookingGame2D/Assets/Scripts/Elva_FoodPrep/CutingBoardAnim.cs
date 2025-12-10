using UnityEngine;

public class CutingBoardAnim : MonoBehaviour
{
    public Animator anim;
    public PressKeys mashGate;



    public bool IsBoardReady()
    {
        if (anim == null) return true;

        return anim.speed == 0f;
    }

    void Update()
    {
        if (!anim || !mashGate) return;

        
        anim.speed = mashGate.canCut ? 0f : 1f;
    }
}
