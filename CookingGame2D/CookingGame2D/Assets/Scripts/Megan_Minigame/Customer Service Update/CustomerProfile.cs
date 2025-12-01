using System.Collections.Generic;
using UnityEngine;

public class CustomerProfile : MonoBehaviour
{
    //Check the score and React to questions in this script

    public string customerName;
    public GameObject Background;

    public string[] dislikedMenuItems;
    public string[] likedMenuItems;
    public string favoriteMenuItems;

    public string targetMenuItem; 

    private BasicCustomerManager customerManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Change Name UI
        //Change Background UI
        //Change Profile UI
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
