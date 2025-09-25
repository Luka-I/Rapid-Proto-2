using UnityEngine;
using UnityEngine.UI; // If you're displaying it on UI Text

public class EnemyCounter : MonoBehaviour
{
    public int totalEnemies = 30;   // total enemies required
    private int remainingEnemies;   // how many are left
    public Text counterText;        // UI text to display "x/30"

    void Start()
    {
        remainingEnemies = totalEnemies;
        UpdateCounterUI();
    }

    // Call this whenever an enemy dies
    public void EnemyKilled()
    {
        remainingEnemies--;

        if (remainingEnemies < 0)
            remainingEnemies = 0;

        UpdateCounterUI();
    }

    void UpdateCounterUI()
    {
        counterText.text = remainingEnemies + "/" + totalEnemies;
    }
}