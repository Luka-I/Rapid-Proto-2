using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // List to keep track of enemies within the trigger area
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    // Methods to add and remove enemies from the list
    public void AddEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }
}