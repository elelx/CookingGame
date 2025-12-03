using System.Collections;
using UnityEngine;

public class SoupButton : MonoBehaviour
{
    public Transform customerFolder;         // Folder containing all customers
    public SoupManager soupManager;          // Soup system reference
    public CustomerInteractionManager interactionManager;

    public void OnSoupClicked()
    {
        StartCoroutine(SwitchCustomerAfterDelay());
    }

    private IEnumerator SwitchCustomerAfterDelay()
    {
        // 1. Find current active customer index
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
            Debug.LogError("❌ No customer active at the start!");
            yield break;
        }

        GameObject currentCustomer = customerFolder.GetChild(currentIndex).gameObject;

        Debug.Log("Switching from: " + currentCustomer.name);

        // 2. Score the soup
        CustomerProfile profile = currentCustomer.GetComponent<CustomerProfile>();
        if (profile != null && soupManager.HasFinishedSoup())
        {
            profile.ReceiveSoup(soupManager.currentSoupName);
        }

        //// Wait for reaction
        //yield return new WaitForSeconds(5f);

        // End UI + dialogue
        interactionManager?.EndInteraction();

        // 3. Determine the next customer index
        int nextIndex = (currentIndex + 1) % customerFolder.childCount;
        GameObject nextCustomer = customerFolder.GetChild(nextIndex).gameObject;

        Debug.Log("→ Changing to: " + nextCustomer.name);

        // 4. Deactivate all customers
        foreach (Transform c in customerFolder)
            c.gameObject.SetActive(false);

        // 5. Activate next customer
        nextCustomer.SetActive(true);

        // 6. Reset soup for next round
        soupManager.ServeSoup();
    }
}
