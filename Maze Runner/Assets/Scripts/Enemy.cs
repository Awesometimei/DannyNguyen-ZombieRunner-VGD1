using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject target;
    public int damage;
    public int hp;
    public GameObject hitParticle;
    public GameObject bloodParticles;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Defines what the enemyRb is for later reference
        enemyRb = GetComponent<Rigidbody>();
        //References the player for later use
        target = GameObject.Find("BasePoint");
    }

    // Update is called once per frame
    void Update()
    {   //Defines what lookDirection is for later reference
        Vector3 lookDirection = (target.transform.position - transform.position).normalized;

        //Adds force on the player depending on player's and its own location times the speed
        enemyRb.AddForce(lookDirection * speed);

        if (hp == 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy destroyed");
        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            if (hp != 0)
            {
                InflictDamage(1);
                HitEffects();
            }
        }
    }

    void InflictDamage(int damage)
    {
        hp -= damage;
    }

    void HitEffects()
    {
        Instantiate(hitParticle, transform.position, player.transform.rotation);
        Instantiate(bloodParticles, transform.position, player.transform.rotation);
    }

}

