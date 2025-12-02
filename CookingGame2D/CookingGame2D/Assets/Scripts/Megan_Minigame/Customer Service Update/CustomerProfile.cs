using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerProfile : MonoBehaviour
{
    //Check the score and React to questions in this script

    [Header("Customer Information")]
    public string customerName;
    public GameObject Background;
    public GameObject characterProfilePage;

    public string[] dislikedMenuItems;
    public string[] likedMenuItems;
    public string favoriteMenuItems;

    [Header("Interaction Managment")]
    public string targetMenuItem; 
    private BasicCustomerManager customerManager;

    public void StartThisCharacterInteraction()
    {
        //ADD Deactivate Background
        //ADD Deactivate Profile UI
    }

    public void EndThisCharacterInteraction()
    {
        //ADD Make Background dissapear
        //ADD Make Character Profile dissapear
    }

    public void ItemResponce()
    {
        // Favorite
        if (targetMenuItem == favoriteMenuItems)
        {
            Debug.Log("Favorite Food!");
            ScoreManager.Instance.AddPoints(5);
            // trigger heart animation here
            return;
        }

        // Liked (using array check)
        if (System.Array.Exists(likedMenuItems, item => item == targetMenuItem))
        {
            Debug.Log("Liked Food!");
            ScoreManager.Instance.AddPoints(3);
            // thumbs up animation
            return;
        }

        // Disliked (using array check)
        if (System.Array.Exists(dislikedMenuItems, item => item == targetMenuItem))
        {
            Debug.Log("Disliked Food!");
            ScoreManager.Instance.AddPoints(0);
            // angry animation
            return;
        }

        Debug.Log("Unknown food (0 points)");
    }


    public void ReceiveSoup(string soupName)
    {
        targetMenuItem = soupName;
        ItemResponce();
    }

}
