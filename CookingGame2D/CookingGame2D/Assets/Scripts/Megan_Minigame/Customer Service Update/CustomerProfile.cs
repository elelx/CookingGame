using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

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

    public SpriteRenderer customerReationSprite;
    public Sprite happySprite;
    public Sprite neutralSprite;
    public Sprite angrySprite;
    public TMP_Text reactionText;

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

    public void PauseEmotionTimer()
    {
        customerManager.PauseTimer();
    }

    public void ItemResponce()
    {
        customerManager = GetComponent<BasicCustomerManager>();
        customerManager.ResetEmotion();

        // Favorite
        if (targetMenuItem == favoriteMenuItems)
        {
            Debug.Log("Favorite Food!");
            customerReationSprite.sprite = happySprite;
            ScoreManager.Instance.AddPoints(5);

            if (reactionText != null)
                reactionText.text = "Amazing! That's my FAVORITE!";

            return;
        }

        // Liked
        if (System.Array.Exists(likedMenuItems, item => item == targetMenuItem))
        {
            Debug.Log("Liked Food!");
            customerReationSprite.sprite = neutralSprite;
            ScoreManager.Instance.AddPoints(3);

            if (reactionText != null)
                reactionText.text = "Yum! I like this one!";

            return;
        }

        // Disliked
        if (System.Array.Exists(dislikedMenuItems, item => item == targetMenuItem))
        {
            Debug.Log("Disliked Food!");
            customerReationSprite.sprite = angrySprite;
            ScoreManager.Instance.AddPoints(0);

            if (reactionText != null)
                reactionText.text = "Ugh... I don’t like this...";

            return;
        }

        Debug.Log("Unknown food (0 points)");
        if (reactionText != null)
            reactionText.text = "I don't know what this is...";
    }

    public void ItemResponceUnscored()
    {
        customerManager = GetComponent<BasicCustomerManager>();
        customerManager.ResetEmotion();

        // Favorite
        if (targetMenuItem == favoriteMenuItems)
        {
            customerReationSprite.sprite = happySprite;

            if (reactionText != null)
                reactionText.text = "Amazing! That's my FAVORITE!";

            return;
        }

        // Liked
        if (System.Array.Exists(likedMenuItems, item => item == targetMenuItem))
        {
            customerReationSprite.sprite = neutralSprite;

            if (reactionText != null)
                reactionText.text = "Yum! I like this one!";

            return;
        }

        // Disliked
        if (System.Array.Exists(dislikedMenuItems, item => item == targetMenuItem))
        {
            customerReationSprite.sprite = angrySprite;

            if (reactionText != null)
                reactionText.text = "Ugh... I don’t like this...";

            return;
        }

        Debug.Log("Unknown food");
        if (reactionText != null)
            reactionText.text = "I don't know what this is...";
    }



    public void ReceiveSoup(string soupName)
    {
        targetMenuItem = soupName;
        ItemResponce();
    }

    public void ResetForNextCustomer()
    {
        customerReationSprite.sprite = neutralSprite;
        if (reactionText != null) reactionText.text = "";
    }

}
