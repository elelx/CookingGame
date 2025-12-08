using UnityEngine;

public class Cut : MonoBehaviour
{
    bool holdingKnife;
    Vector3 lastPos;
    public float minMoveSpeed = 0.05f;
    public bool isMoving;

    void Start()
    {
        lastPos = transform.position;
    }

    void OnMouseDown()
    {
        holdingKnife = true;
        lastPos = transform.position;
    }

    void OnMouseUp()
    {
        holdingKnife = false;
        isMoving = false;
    }

    void Update()
    {
        if (!holdingKnife)
        {
            isMoving = false;
            return;
        }

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        transform.position = mouse;

        float moveAmount = Vector3.Distance(transform.position, lastPos);
        isMoving = moveAmount > minMoveSpeed;

        lastPos = transform.position;
    }

}
