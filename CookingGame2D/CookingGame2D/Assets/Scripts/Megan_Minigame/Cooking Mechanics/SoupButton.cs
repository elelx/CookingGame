using UnityEngine;

public class SoupButton : MonoBehaviour
{
    public GameObject customerToActivate;
    public Transform customerFolder;
    public SoupManager soupManager;

    public void OnSoupClicked()
    {
        // Disable all customers
        foreach (Transform c in customerFolder)
            c.gameObject.SetActive(false);

        // Enable assigned customer
        customerToActivate.SetActive(true);

        // Reset pot + ingredients + hide soup
        soupManager.ServeSoup();
    }
}
