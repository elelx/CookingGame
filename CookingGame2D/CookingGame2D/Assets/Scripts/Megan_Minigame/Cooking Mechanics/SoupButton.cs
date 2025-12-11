using System.Collections;
using UnityEngine;

public class SoupButton : MonoBehaviour
{
    public Transform customerFolder;
    public SoupManager soupManager;
    public CustomerInteractionManager interactionManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CustomerInteractionManager.playerIsTyping == false)
            {
                ServeSoup();
            }
        }
    }

    // 🔥 Call this from the UI Button
    public void ServeSoup()
    {
        StartCoroutine(SwitchCustomerAfterDelay());
    }

    private IEnumerator SwitchCustomerAfterDelay()
    {
        CustomerRotationManager rotation = FindAnyObjectByType<CustomerRotationManager>();
        GameObject currentCustomer = rotation.GetCurrentCustomer();

        CustomerProfile profile = currentCustomer.GetComponent<CustomerProfile>();

        // Pause emotion timer
        profile.PauseEmotionTimer();

        // Score soup
        if (profile != null && soupManager.HasFinishedSoup())
        {
            profile.ReceiveSoup(soupManager.currentSoupName);
            profile.ResetForNextCustomer();
        }

        yield return new WaitForSeconds(1f);

        interactionManager?.EndInteraction();


        // Move to next customer
        rotation.MoveToNextCustomer();

        soupManager.ServeSoup();
        interactionManager?.StartInteraction();
    }

}
