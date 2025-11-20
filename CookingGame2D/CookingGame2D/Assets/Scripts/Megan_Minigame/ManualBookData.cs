using System.Collections.Generic;
using UnityEngine;

public class ManualBookData : MonoBehaviour
{
    [System.Serializable]
    public class DialoguePair
    {
        public string customer;   // what the customer says
        public string reply;      // the correct reply player should give
    }

    [Header("Dialogue List (Customer → Correct Reply)")]
    public List<DialoguePair> dialoguePairs = new List<DialoguePair>();

    private int currentIndex = 0;

    public DialoguePair GetCurrentDialogue()
    {
        return dialoguePairs[currentIndex];
    }

    public string GetCurrentCustomerLine()
    {
        return dialoguePairs[currentIndex].customer;
    }

    public string GetCurrentCorrectReply()
    {
        return dialoguePairs[currentIndex].reply;
    }

    public void NextDialogue()
    {
        currentIndex++;

        if (currentIndex >= dialoguePairs.Count)
        {
            currentIndex = 0; 
        }
    }
}
