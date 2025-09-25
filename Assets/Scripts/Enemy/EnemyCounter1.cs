using UnityEngine;
using TMPro; // add this for TextMeshPro

public class EnemyCounter : MonoBehaviour
{
    public int totalEnemies = 30;   // total enemies required
    private int remainingEnemies;   // how many are left
    public TextMeshProUGUI counterText; // TMP instead of UI.Text

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
