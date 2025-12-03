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
}


