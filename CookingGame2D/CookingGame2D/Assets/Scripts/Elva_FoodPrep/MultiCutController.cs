using UnityEngine;

public class MultiCutController : MonoBehaviour
{
    public string ingredientName = "fish";

    public CuttingAnim[] pieces;
    public Drag[] dragPieces;

    public int totalPieces;
    public int piecesFinished;

    public GameObject doneButton;
    public PressKeys mashGate;

    void Start()
    {
        piecesFinished = 0;

        totalPieces = pieces.Length + dragPieces.Length;

        if (doneButton)
            doneButton.SetActive(false);

        foreach (var p in pieces)
            p.SetParentController(this, mashGate);

        foreach (var d in dragPieces)
            d.manager = this;

    }

    public void NotifyPieceFinished()
    {
        piecesFinished++;

        Debug.Log("Finished piece! Count: " + piecesFinished + " / " + totalPieces);

        if (piecesFinished >= totalPieces)
        {
            Debug.Log("ALL DONE!");

            if (doneButton)
                doneButton.SetActive(true);
        }
    }

    public void OnDoneButtonPressed()
    {
        Inventory.Instance.AddItem(ingredientName);
        ResetIngredient();
    }

    public void ResetIngredient()
    {
        Debug.Log("Resetting ingredient...");

        piecesFinished = 0;

        foreach (var p in pieces)
            p.ResetCutPiece();

        foreach (var d in dragPieces)
            d.ResetDrag();    

        if (doneButton)
            doneButton.SetActive(false);
    }
}
