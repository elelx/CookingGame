using System.Collections;
using UnityEngine;

public class SoupButton : MonoBehaviour
{
    public Transform customerFolder;
    public SoupManager soupManager;
    public CustomerInteractionManager interactionManager;
    public bool customerIsSwitching = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CustomerInteractionManager.playerIsTyping == false && customerIsSwitching == false)
            {
                customerIsSwitching = true;
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
        customerIsSwitching = true;

        CustomerRotationManager rotation = FindAnyObjectByType<CustomerRotationManager>();
        GameObject currentCustomer = rotation.GetCurrentCustomer();

        //CustomerProfile profile = currentCustomer.GetComponent<CustomerProfile>();
        CustomerProfile profile = FindFirstObjectByType<CustomerProfile>();

        // Pause emotion timer
        profile.PauseEmotionTimer();

        // Score soup
        if (profile != null && soupManager.HasFinishedSoup())
        {
            Debug.Log("Log Score");
            profile.ReceiveSoup(soupManager.currentSoupName);
            profile.ResetForNextCustomer();
        }

        yield return new WaitForSeconds(2f);

        interactionManager?.EndInteraction();

        soupManager.ServeSoup();

        // Move to next customer
        rotation.MoveToNextCustomer();

        interactionManager?.StartInteraction();

        customerIsSwitching = false;
    }

}
