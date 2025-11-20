using UnityEngine;
using TMPro;

public class ServicePoints : MonoBehaviour
{
    public TMP_Text scoreText;
    private int totalPoints = 0;

    public void AddPoints(int p)
    {
        totalPoints += p;
        scoreText.text = "Points: " + totalPoints;
    }
}
