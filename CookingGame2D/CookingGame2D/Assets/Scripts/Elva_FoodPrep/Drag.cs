using UnityEngine;

public class Drag : MonoBehaviour
{
    public DragMan manager;   
    public float dragThreshold = 100f;  

    Vector3 startPos;

    bool done = false;

    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDrag()
    {
        if (done) return;

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
}
