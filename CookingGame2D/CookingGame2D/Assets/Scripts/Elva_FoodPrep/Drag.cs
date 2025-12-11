using UnityEngine;

public class Drag : MonoBehaviour
{
    public MultiCutController manager;

    public PressKeys mashGate;

    public float dragThreshold = 100f;

    public CutingBoardAnim boardGate;

    Vector3 startLocalPos;

    bool done;

    void Awake()
    {
        startLocalPos = transform.localPosition;
    }
    void OnMouseDrag()
    {
        if (done) return;

        if (!mashGate || !mashGate.canCut) return;

        if (boardGate && !boardGate.IsBoardReady()) return;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;
        if (Vector3.Distance(transform.position, transform.parent.TransformPoint(startLocalPos)) > dragThreshold)
        {
            done = true;
            manager.NotifyPieceFinished();
            gameObject.SetActive(false);

        }
    }
    public void ResetDrag()
    {
        done = false;
        transform.localPosition = startLocalPos;
        gameObject.SetActive(true);

    }
}
