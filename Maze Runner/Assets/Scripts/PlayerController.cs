using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 8.0f;
    private float horizontalInput;
    private float forwardInput;

    public GameObject projectilePrefab;

    private bool CanShoot = true;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {   
        forwardInput = Input.GetAxis("Vertical");                                                     //Gets input of w and s keys
        horizontalInput = Input.GetAxis ("Horizontal");                                               //Gets input of a and d keys
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);                 //Moves the player based on the input of w and s keys
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);                //Moves the player based on the input of a and d keys

        if (Input.GetMouseButtonDown(0) && CanShoot) {                                                //Gives player ability to fire projectile when the left click button is pressed & the firing cooldown is over                                    
            Instantiate(projectilePrefab, transform.position, transform.rotation);                    //Creates a projectile at and facing the player
            CanShoot = false;                                                                         //Prevents player from spam firing projectiles
            StartCoroutine(ShootingCooldown());                                                       //Starts cooldown until player can shoot again
        }
        
    }

    IEnumerator ShootingCooldown()  
    {
        yield return new WaitForSeconds(0.1f);                                                        //Sets a timer for the cooldown until player can shoot again
        CanShoot = true;                                                                              //Allows player to shoot again
    }
}

