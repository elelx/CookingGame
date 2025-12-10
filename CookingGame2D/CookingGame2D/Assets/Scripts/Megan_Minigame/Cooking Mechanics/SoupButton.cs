using System.Collections;
using UnityEngine;

public class SoupButton : MonoBehaviour
{
    public Transform customerFolder;
    public SoupManager soupManager;
    public CustomerInteractionManager interactionManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            ServeSoup();
        }
    }

    // 🔥 Call this from the UI Button
    public void ServeSoup()
    {
        StartCoroutine(SwitchCustomerAfterDelay());
    }

    private IEnumerator SwitchCustomerAfterDelay()
    {
        int currentIndex = -1;

        for (int i = 0; i < customerFolder.childCount; i++)
        {
            if (customerFolder.GetChild(i).gameObject.activeSelf)
            {
                currentIndex = i;
                break;
            }
        }

        if (currentIndex == -1)
        {
            Debug.LogError("❌ No customer active!");
            yield break;
        }

        GameObject currentCustomer = customerFolder.GetChild(currentIndex).gameObject;

        // Score the soup
        CustomerProfile profile = currentCustomer.GetComponent<CustomerProfile>();
        if (profile != null && soupManager.HasFinishedSoup())
        {
            profile.ReceiveSoup(soupManager.currentSoupName);
        }

        interactionManager?.EndInteraction();

        // Switch to next customer
        int nextIndex = (currentIndex + 1) % customerFolder.childCount;

        foreach (Transform c in customerFolder)
            c.gameObject.SetActive(false);

        customerFolder.GetChild(nextIndex).gameObject.SetActive(true);

        soupManager.ServeSoup();
    }
}
