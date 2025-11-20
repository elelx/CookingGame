using UnityEngine;
using UnityEngine.InputSystem;

public class CookableFood : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color cookedColor = Color.black;
    public float burnTime = 5f;

    private bool isCooking = false;
    private float burnTimer = 0f;

    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, 0f);
        }

        if (isCooking)
        {
            burnTimer += Time.deltaTime;
            float t = burnTimer / burnTime;
            sprite.color = Color.Lerp(Color.white, cookedColor, t);

            if (burnTimer >= burnTime) isCooking = false;
        }
    }

    void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, 0f);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    public void StartCooking()
    {
        isCooking = true;
        burnTimer = 0f;
    }

    public void StopCooking()
    {
        isCooking = false;
    }
}
