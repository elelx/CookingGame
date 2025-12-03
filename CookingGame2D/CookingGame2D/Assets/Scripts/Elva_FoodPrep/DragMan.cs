using UnityEngine;

public class DragMan : MonoBehaviour
{
    public Drag[] pieces; 
    int removedCount = 0;

    public enum PrepType { Shrimp, Snail, Mushroom, Garlic }
    public PrepType prepType;

    public GameObject snailBody;
    public GameObject snailshell;

    public GameObject finishedShrimp;
    public GameObject newMushroom;
    public GameObject garlic;


    public PressKeys cutScript; 

    void Start()
    {
        foreach (var p in pieces)
            p.manager = this;

        snailBody.SetActive(false);


    }

    public void PieceRemoved(Drag p)
    {
        removedCount +=1;

        if (removedCount == pieces.Length)
        {
            OnCompleted();
        }
    }

    void OnCompleted()
    {
        Debug.Log("OnCompleted() entered!");


        switch (prepType)
        {
            case PrepType.Shrimp:

                finishedShrimp.SetActive(true);

                break;

            case PrepType.Snail:

                Debug.Log("Switch matched: SNAIL");

                Debug.Log("snailBody is " + (snailBody == null ? "NULL" : "NOT NULL"));

                snailshell.SetActive(false);
                snailBody.SetActive(true);

                cutScript.enabled = true;

               





                break;

            case PrepType.Mushroom:

                Instantiate(newMushroom, transform.position, Quaternion.identity);

                break;

            case PrepType.Garlic:

                garlic.SetActive(true);


                cutScript.enabled = true;
                break;
        }

        Debug.Log($"{prepType} completed!");
    }
}
