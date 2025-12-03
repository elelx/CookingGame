using UnityEngine;

public class MultiCutController : MonoBehaviour
{
    public CuttingAnim[] pieces;   
    public int totalPieces;        
    public int piecesFinished;     

    public GameObject doneButton;  
    public PressKeys mashGate;     

    void Start()
    {
        totalPieces = pieces.Length;
        piecesFinished = 0;

        if (doneButton)
        {
            doneButton.SetActive(false);
        }
            
        foreach (var p in pieces)
        {
            p.SetParentController(this, mashGate);
        }
            
    }

    public void NotifyPieceFinished()
    {
        piecesFinished += 1;

        Debug.Log(" finished! Count: " + piecesFinished + "out of " + totalPieces);

        if (piecesFinished >= totalPieces)
        {
            Debug.Log("ALL  DONE!");

            if (doneButton)
            {
                doneButton.SetActive(true);
            }

        }
    }

    public void ResetIngredient()
    {
        Debug.Log("Resetting ingredient...");

        piecesFinished = 0;

        foreach (var p in pieces)
        {
            p.ResetCutPiece();
        }

        if (doneButton)
            doneButton.SetActive(false);
    }
}
