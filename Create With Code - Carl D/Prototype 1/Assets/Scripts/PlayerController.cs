using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Protected allows the variable or method to be accessible from outside this script, but only those which inherit the class in which it is.
    [SerializeField] protected float speed = 20.0f;

    // Variables that are declared as const cannot later be changed in the script anywhere else.
    private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    public string inputID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get controller input
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        //Move the vehicle forward.
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotate the vehicle based on horizontal input
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);        
    }
}
