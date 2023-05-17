using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFunction : MonoBehaviour
{
    public float leftBoundary;
    public float rightBoundary;
    public float topBoundary;
    public float bottomBoundary;
    public float speed; //Speed the projectile will move at

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < topBoundary) {
            Destroy(gameObject);
        }

        if (transform.position.x > bottomBoundary) {
            Destroy(gameObject);
        }

        if (transform.position.z > rightBoundary) {
            Destroy(gameObject);
        }

        if (transform.position.z < leftBoundary) {
            Destroy(gameObject);
        }

          transform.Translate(Vector3.forward * speed * Time.deltaTime); //Moves the projectile forward
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Collided with enemy");
        }

        if (other.gameObject.CompareTag("Building"))
        {
            Destroy(gameObject);
            Debug.Log("Collided with building");
        }
    }
}