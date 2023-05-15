using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //Defines what the enemyRb is for later reference
        enemyRb = GetComponent<Rigidbody>();
        //References the player for later use
        target = GameObject.Find("Base");
    }

    // Update is called once per frame
    void Update()
    {   //Defines what lookDirection is for later reference
        Vector3 lookDirection = (target.transform.position - transform.position).normalized;

        //Adds force on the player depending on player's and its own location times the speed
        enemyRb.AddForce(lookDirection * speed);
    }
   
   void OnTriggerEnter (Collision other)
    {
            Destroy(gameObject);
            Destroy(other.gameObject);
    }

    

}

