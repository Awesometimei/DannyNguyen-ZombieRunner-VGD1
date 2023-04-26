using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Defines what the enemyRb is for later reference
        enemyRb = GetComponent<Rigidbody>();
        //References the player for later use
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   //Defines what lookDirection is for later reference
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //Adds force on the player depending on player's and its own location times the speed
        enemyRb.AddForce(lookDirection * speed);
    }
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile")){
            Destroy(gameObject);
        } 
    }

    

}

