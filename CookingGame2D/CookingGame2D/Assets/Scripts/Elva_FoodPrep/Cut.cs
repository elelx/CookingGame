using UnityEngine;

public class Cut : MonoBehaviour
{
    bool holdingKnife;

    void OnMouseDown()
    {
        holdingKnife = true;
    }

    void OnMouseUp()
    {
        holdingKnife = false;
    }

    void Update()
    {
        if (holdingKnife)
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            transform.position = mouse;
        }
    }

}
