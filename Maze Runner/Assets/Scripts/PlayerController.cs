using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 8.0f;
    private float horizontalInput;
    private float forwardInput;
    private float firingCooldown = 0.20f;
    private float fasterFiringCooldown = 0.075f;
    private float topBoundary = -88.0f;
    private float bottomBoundary = -7.0f;
    private float rightBoundary = 25.2f;
    private float leftBoundary = -8.75f;

    public GameObject projectilePrefab;
    private GameManager gameManager;

    private bool canShoot = true;
    public bool hasInstaKill = false;
    public bool hasDoubleDamage = false;
    public bool hasFasterFiring = false;

    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {   
        if(gameManager.isGameActive == true)
        {
            forwardInput = Input.GetAxis("Vertical");                                               
            horizontalInput = Input.GetAxis ("Horizontal");                                             
            transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);                 
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);               

        if (Input.GetMouseButtonDown(0) && canShoot) 
            {                                              
                Instantiate(projectilePrefab, transform.position, transform.rotation);                   
                if (hasDoubleDamage == true)
                {
                    Instantiate(projectilePrefab, transform.position, transform.rotation);
                }
                canShoot = false;                                                                    
                StartCoroutine(ShootingCooldown());                                              
            }
        }

         if (transform.position.x < topBoundary)
        {
            transform.position = new Vector3 (topBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.x > bottomBoundary)
        {
            transform.position = new Vector3 (bottomBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.z < leftBoundary)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, leftBoundary);
        }

          if (transform.position.z > rightBoundary)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, rightBoundary);
        }
        
    }

    IEnumerator ShootingCooldown()  
    {   
        if (hasFasterFiring == true)
        {
           yield return new WaitForSeconds(fasterFiringCooldown);   
        }
        else
        {
            yield return new WaitForSeconds(firingCooldown);   
        }                                                                                             
          canShoot = true;                                                                              
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InstaKill"))
        {
           hasInstaKill = true;
           Destroy(other.gameObject);
           StartCoroutine(PowerupCooldown());
        }

        if (other.gameObject.CompareTag("DoubleTap"))
        {
            hasDoubleDamage = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCooldown());
        }

        if (other.gameObject.CompareTag("FasterFiring"))
        {
            hasFasterFiring = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCooldown());
        }
    }

    IEnumerator PowerupCooldown()
    {
        if (hasInstaKill == true)
        {
            yield return new WaitForSeconds(20);
            hasInstaKill = false;
        }

        if (hasDoubleDamage == true)
        {
            yield return new WaitForSeconds(20);
            hasDoubleDamage = false;
        }

        if (hasFasterFiring == true)
        {
            yield return new WaitForSeconds(20);
            hasFasterFiring = false;
        }
    }
}

