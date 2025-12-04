using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChoppedFood : MonoBehaviour
{
    public Image potCookingSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (potCookingSprite != null)
            potCookingSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void choppedfood()
    {
        if (potCookingSprite != null)
            potCookingSprite.enabled = true;

    }

}

