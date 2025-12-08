using UnityEngine;

public class DragMan : MonoBehaviour
{
    public Drag[] pieces;
    public CuttingAnim[] cutPieces;

    int removedCount = 0;

    public enum PrepType { Shrimp, Snail, Mushroom, Garlic }
    public PrepType prepType;

    public GameObject snailBody;
    public GameObject snailshell;

    public GameObject finishedShrimp;
    public GameObject newMushroomPrefab;
    public GameObject garlic;

    GameObject spawnedMushroom;
    public PressKeys cutScript; 

    void Start()
    {
        foreach (var p in pieces)
            p.manager = this;

    //    ResetAll();


    }

    public void PieceRemoved(Drag p)
    {
        removedCount +=1;

        if (removedCount >= pieces.Length)
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

                snailshell.SetActive(false);
                snailBody.SetActive(true);

                cutScript.enabled = true;

                break;

            case PrepType.Mushroom:

                spawnedMushroom =
                      Instantiate(newMushroomPrefab, transform.position, Quaternion.identity);
                break;

            case PrepType.Garlic:

                garlic.SetActive(true);

                cutScript.enabled = true;
                break;
        }

        Debug.Log($"{prepType} completed!");
    }

    public void ResetAll()
    {
        Debug.Log("RESET ALL");

        removedCount = 0;
        foreach (var p in pieces)
            p.ResetDrag();

        foreach (var c in cutPieces)
            c.ResetCutPiece();

        if (cutScript)
            cutScript.enabled = false;

        if (snailBody) snailBody.SetActive(false);
        if (snailshell) snailshell.SetActive(true);
        if (finishedShrimp) finishedShrimp.SetActive(false);
        if (garlic) garlic.SetActive(false);

        if (spawnedMushroom)
            Destroy(spawnedMushroom);
    }

}
