using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> powerups;

    public int enemyCount;
    public int waveNumber = 1;

    private float topSpawnRange = -104.0f;
    private float rightSpawnRange = 25.2f;
    private float leftSpawnRange = -8.75f;
    private float bottomSpawnRange = -90.0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {   
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    private Vector3 GenerateSpawnPosition () {
        float spawnPosX = Random.Range(topSpawnRange,bottomSpawnRange);
        float spawnPosZ = Random.Range(leftSpawnRange,rightSpawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, -15.25f, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {   
        if (gameManager.isGameActive == true)
        {
            StartEnemySpawning();
        }
    }
    
    public void SpawnEnemyWave(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn; i++) 
        { 
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    public void StartEnemySpawning()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) 
        { 
            waveNumber++;
            gameManager.IncreaseMultiplier();
            SpawnEnemyWave(waveNumber);
            int index = Random.Range(0, powerups.Count);
            Instantiate(powerups[index]);
        }
    }

}
