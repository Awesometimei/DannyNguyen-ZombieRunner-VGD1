using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public float xLimit;
    public float zLimit;

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
    }
}
