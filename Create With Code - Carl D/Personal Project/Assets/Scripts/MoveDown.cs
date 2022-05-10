using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float zBound = -10.0f;
    public float speed = 5.0f;
    public Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }
}
