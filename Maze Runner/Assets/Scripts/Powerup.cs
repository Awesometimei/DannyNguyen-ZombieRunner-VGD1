using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float topSpawnRange = -60.0f;
    private float rightSpawnRange = 25.2f;
    private float leftSpawnRange = -8.75f;
    private float bottomSpawnRange = -18.5f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Awake()
    {
        transform.position = new Vector3(Random.Range(topSpawnRange, bottomSpawnRange), -15.75f, Random.Range(leftSpawnRange, rightSpawnRange));
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive == false)
        {
            Destroy(gameObject);
        }
    }
}
