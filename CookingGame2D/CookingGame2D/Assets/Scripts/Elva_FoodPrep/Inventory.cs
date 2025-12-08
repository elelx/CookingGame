using UnityEngine;

public class Inventory : MonoBehaviour
{
 
    public static Inventory Instance;

    private int shrimp = 0;
    private int snail = 0;
    private int tbone = 0;
    private int mushroom = 0;
    private int sausge = 0;
    private int fish = 0;
    private int carrot = 0;
    private int onion = 0;
    private int garlic = 0;
    private int bug = 0;
    private int kelp = 0;


    void Awake()
    {
        Instance = this;
    }

    public void AddItem(string itemName)
    {
        if (itemName == "shrimp") shrimp++;
        if (itemName == "snail") snail++;
        if (itemName == "mushroom") mushroom++;
        if (itemName == "tbone") tbone++;
        if (itemName == "fish") fish++;
        if (itemName == "sausge") sausge++;
        if (itemName == "bug") bug++;
        if (itemName == "garlic") garlic++;
        if (itemName == "onion") onion++;
        if (itemName == "carrot") carrot++;
        if (itemName == "kelp") kelp++;


        Debug.Log("add " + itemName + "have ");


        Debug.Log("shrimp: " + shrimp);
        Debug.Log("snail: " + snail);
        Debug.Log("mushroom: " + mushroom);
        Debug.Log("tbone: " + tbone);
        Debug.Log("sausge: " + sausge);
        Debug.Log("fish: " + fish);
        Debug.Log("bug: " + bug);
        Debug.Log("garlic: " + garlic);
        Debug.Log("onion: " + onion);
        Debug.Log("carrot: " + carrot);
        Debug.Log("kelp: " + kelp);

    }

    public bool HasItem(string itemName)
    {
        itemName = itemName.ToLower();

        if (itemName == "shrimp") return shrimp > 0;
        if (itemName == "snail") return snail > 0;
        if (itemName == "mushroom") return mushroom > 0;
        if (itemName == "tbone") return tbone > 0;
        if (itemName == "fish") return fish > 0;
        if (itemName == "sausge") return sausge > 0;
        if (itemName == "bug") return bug > 0;
        if (itemName == "garlic") return garlic > 0;
        if (itemName == "onion") return onion > 0;
        if (itemName == "carrot") return carrot > 0;
        if (itemName == "kelp") return kelp > 0;

        return false;
    }

    public void UseItem(string itemName)
    {
        itemName = itemName.ToLower();

        if (itemName == "shrimp" && shrimp > 0) shrimp--;
        if (itemName == "snail" && snail > 0) snail--;
        if (itemName == "mushroom" && mushroom > 0) mushroom--;
        if (itemName == "tbone" && tbone > 0) tbone--;
        if (itemName == "fish" && fish > 0) fish--;
        if (itemName == "sausge" && sausge > 0) sausge--;
        if (itemName == "bug" && bug > 0) bug--;
        if (itemName == "garlic" && garlic > 0) garlic--;
        if (itemName == "onion" && onion > 0) onion--;
        if (itemName == "carrot" && carrot > 0) carrot--;
        if (itemName == "kelp" && kelp > 0) kelp--;
    }


}


