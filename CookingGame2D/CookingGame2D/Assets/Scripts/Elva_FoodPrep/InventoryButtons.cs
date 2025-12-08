using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class InventoryButtons : MonoBehaviour
{
    public string ingredientName;

    public Sprite fullSprite;
    public Sprite emptySprite;

    public AudioSource sfx;
    public AudioClip emptyClickClip;

    Image img;
    Button btn;

    void Awake()
    {
        img = GetComponent<Image>();
        Refresh();
        btn = GetComponent<Button>();

        btn.onClick.AddListener(OnButtonClicked);
        Refresh();
    }

    void Update()
    {
        Refresh();
    }
    void Refresh()
    {
        if (Inventory.Instance == null) return;

        bool hasItem = Inventory.Instance.HasItem(
            ingredientName.Trim().ToLower()
        );

        img.sprite = hasItem ? fullSprite : emptySprite;
    }

    void OnButtonClicked()
    {
        bool hasItem = Inventory.Instance.HasItem(
            ingredientName.Trim().ToLower()
        );

        if (!hasItem)
        {
           
            if (sfx && emptyClickClip)
                sfx.PlayOneShot(emptyClickClip);
        }
      
    }
}
