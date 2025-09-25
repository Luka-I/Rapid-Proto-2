using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;       // The enemy prefab to track
    public int totalEnemies;             // Will be set automatically if left 0

    [Header("UI")]
    public TextMeshProUGUI counterText;

    private int remainingEnemies;

    void Start()
    {
        // Count all enemies of this prefab currently in the scene
        if (totalEnemies == 0 && enemyPrefab != null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyPrefab.tag);
            totalEnemies = enemies.Length;
        }

        remainingEnemies = totalEnemies;
        UpdateCounterUI();
    }

    public void EnemyKilled()
    {
        if (remainingEnemies > 0)
        {
            remainingEnemies--;
            UpdateCounterUI();
        }
    }

    void UpdateCounterUI()
    {
        counterText.text = remainingEnemies + "/" + totalEnemies;
    }
}