using UnityEngine;
using UnityEngine.InputSystem;

public class CookableFood : MonoBehaviour
{
    public Camera dragCamera; // assign manually
    public SpriteRenderer sprite;
    public Color cookedColor = Color.black;
    public float burnTime = 5f;

    private bool isCooking = false;
    private float burnTimer = 0f;

    private bool isDragging = false;
    private Vector3 offset;

    private void Start()
    {
        if (dragCamera == null)
        {
            dragCamera = Camera.current;
        }
    }

    void Update()
    {
        HandleDragging();

        if (isCooking)
        {
            burnTimer += Time.deltaTime;
            float t = burnTimer / burnTime;
            sprite.color = Color.Lerp(Color.white, cookedColor, t);

            if (burnTimer >= burnTime)
                isCooking = false;
        }
    }

    private void HandleDragging()
    {
        // Left mouse button pressed down
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 worldPos = dragCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            worldPos.z = 0;

            Collider2D hit = Physics2D.OverlapPoint(worldPos);
            if (hit != null && hit.gameObject == gameObject)
            {
                offset = transform.position - worldPos;
                isDragging = true;
            }
        }

        // Left mouse button released
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isDragging = false;
        }

        // Drag the object while holding
        if (isDragging)
        {
            Vector3 mousePos = dragCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;
            transform.position = mousePos + offset;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 worldPos = dragCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            worldPos.z = 0;

            Collider2D hit = Physics2D.OverlapPoint(worldPos);
            if (hit != null)
            {
                Debug.Log("Hit object: " + hit.name);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stove"))
        {
            Debug.Log("HIT STOVE");
        }
        else if (other.CompareTag("Customer"))
        {
            Debug.Log("HIT CUSTOMER");
        }
    }

    // Cooking methods
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
