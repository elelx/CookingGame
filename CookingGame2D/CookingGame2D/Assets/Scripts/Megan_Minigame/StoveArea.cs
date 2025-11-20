using UnityEngine;

public class StoveArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        CookableFood food = other.GetComponent<CookableFood>();
        if (food != null) food.StartCooking();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        CookableFood food = other.GetComponent<CookableFood>();
        if (food != null) food.StopCooking();
    }
}
