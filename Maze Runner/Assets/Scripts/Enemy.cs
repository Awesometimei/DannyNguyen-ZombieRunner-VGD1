using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float healthPoints;
    public int scoreValue;
    public int spawnCooldown;
    public int enemyDamage;
    public int weaponDamage;
    private Rigidbody enemyRb;
    private GameObject target;
    public GameObject hitParticle;
    public GameObject bloodParticles;
    private GameManager gameManager;
    public bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        target = GameObject.Find("BasePoint");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(WaveCooldown());
    }

    // Update is called once per frame
    void Update()
    {   
        if (canMove == true)
        {
            Vector3 lookDirection = (target.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }

        if (healthPoints == 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy destroyed");
            gameManager.UpdateScore(scoreValue);
            canMove = false;
        }

        if(gameManager.isGameActive == false)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile") && healthPoints != 0)
        {
            if (GameObject.Find("Human").GetComponent<PlayerController>().hasInstaKill == true)
            {
                Destroy(gameObject);
                HitEffects();
            }
            else
            {
                InflictDamage(weaponDamage);
                HitEffects();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle") && healthPoints != 0)
       {
            InflictDamage(1);
            HitEffects();
       }       

       if(collision.gameObject.CompareTag("Target"))
       {
            Destroy(gameObject);
            gameManager.DamageTarget(enemyDamage);
       }
    }

    void InflictDamage(int weaponDamage)
    {   
        healthPoints -= weaponDamage;
    }

    void HitEffects()
    {
        Instantiate(hitParticle, transform.position, transform.rotation);
        Instantiate(bloodParticles, transform.position, transform.rotation);
    }

    IEnumerator WaveCooldown()
    {
        yield return new WaitForSeconds(spawnCooldown);
        canMove = true;
    }

    public void SetEasyMode()
    {
        speed = 3.0f;
        enemyDamage = 3;
        spawnCooldown = 10;
    }

    public void SetMediumMode()
    {
        speed = 5.0f;
        enemyDamage = 5;
        spawnCooldown = 7;
    }

    public void SetHardMode()
    {
        speed = 7.5f;
        enemyDamage = 150;
        spawnCooldown = 5;
    }
}

