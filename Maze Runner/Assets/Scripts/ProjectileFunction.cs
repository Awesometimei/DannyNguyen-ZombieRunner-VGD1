using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFunction : MonoBehaviour
{
    public float xLimit;
    public float zLimit;
    public float speed; //Speed the projectile will move at

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xLimit) {
            Destroy(gameObject);
        }

        if (transform.position.x < -xLimit) {
            Destroy(gameObject);
        }

        if (transform.position.z > zLimit) {
            Destroy(gameObject);
        }

        if (transform.position.z < -zLimit) {
            Destroy(gameObject);
        }

          transform.Translate(Vector3.forward * speed * Time.deltaTime); //Moves the projectile forward
    }

}