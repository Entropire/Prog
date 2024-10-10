using System.Collections.Generic;
using UnityEngine;

public class Opdracht3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    private List<GameObject> enemies;

    private float timePasses;
    
    private void Start()
    {
        enemies = new List<GameObject>();
    }

    private void Update()
    {
        HandleKeyPressed();
        
        timePasses += Time.deltaTime;

        if (timePasses >= 1)
        {
            SpawnEnemies(3);
            timePasses = 0; 
        }
    }

    private void SpawnEnemies(int amount)
    {
        for (int i = 0; i > amount; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemies.Add(newEnemy);
        }
    }

    private void DestroyEnemies()
    {
        foreach (var enemy in enemies)
        {
            Destroy(enemy);       
        }
        
        enemies.Clear();
    }

    private void HandleKeyPressed()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SpawnEnemies(20);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            DestroyEnemies();
        }
    }
}