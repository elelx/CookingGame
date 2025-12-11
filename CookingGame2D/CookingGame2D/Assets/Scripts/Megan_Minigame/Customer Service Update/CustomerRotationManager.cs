using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerRotationManager : MonoBehaviour
{
    [Header("Ordered Customers (1–8)")]
    public GameObject[] customers;  // Drag your 8 customers here in order

    [Header("Settings")]
    public string resultsSceneName = "ResultsScene";

    private int currentIndex = 0;

    void Start()
    {
        ActivateOnly(currentIndex);
    }

    public GameObject GetCurrentCustomer()
    {
        return customers[currentIndex];
    }

    public GameObject MoveToNextCustomer()
    {
        currentIndex++;

        if (currentIndex >= customers.Length)
        {
            // All customers finished
            SceneManager.LoadScene(resultsSceneName);
            return null;
        }

        ActivateOnly(currentIndex);
        return customers[currentIndex];
    }

    private void ActivateOnly(int index)
    {
        for (int i = 0; i < customers.Length; i++)
            customers[i].SetActive(i == index);
    }
}
