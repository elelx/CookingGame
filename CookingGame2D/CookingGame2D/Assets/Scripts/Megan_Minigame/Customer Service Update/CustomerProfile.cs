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
        if (targetMenuItem == favoriteMenuItems)
        {
            Debug.Log("Favorite");
            //Heart
        }
        else if (targetMenuItem == likedMenuItems[0] || targetMenuItem == likedMenuItems[1] )
        {
            Debug.Log("Like");
            //Thumbs Up
        }
        else if (targetMenuItem == dislikedMenuItems[0] || targetMenuItem == dislikedMenuItems[1] || targetMenuItem == dislikedMenuItems[2] || targetMenuItem == dislikedMenuItems[3] || targetMenuItem == dislikedMenuItems[4])
        {
            Debug.Log("Hate");
            //X
        }

    }

   
}
