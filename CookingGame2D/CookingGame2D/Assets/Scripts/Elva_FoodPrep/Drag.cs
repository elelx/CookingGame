using UnityEngine;

public class Drag : MonoBehaviour
{
    public DragMan manager;
    public PressKeys mashGate;
    public float dragThreshold = 100f;
    public CutingBoardAnim boardGate;

    Vector3 startPos;

    bool done = false;

    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDrag()
    {
        if (done) return;

        if (mashGate == null || !mashGate.canCut)
            return;

        if (boardGate != null && !boardGate.IsBoardReady())
            return;

        Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m.z = 0;
        transform.position = m;

        float dist = Vector3.Distance(transform.position, startPos);

        if (dist > dragThreshold)
        {
            done = true;
            manager.PieceRemoved(this);
            gameObject.SetActive(false);
        }
    }
    public void ResetDrag()
    {
        done = false;
        transform.position = startPos;
        gameObject.SetActive(true);
    }
}
