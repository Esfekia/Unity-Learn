using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Protected allows the variable or method to be accessible from outside this script, but only those which inherit the class in which it is.
    //[SerializeField] protected float speed = 20.0f;

    // Variables that are declared as const cannot later be changed in the script anywhere else.
    private const float turnSpeed = 45.0f;
    [SerializeField]private float horsePower = 0;
    private float horizontalInput;
    private float forwardInput;
    public string inputID;
    private Rigidbody playerRb;
    public GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    [SerializeField] TextMeshProUGUI rpmText;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get controller input
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        //Move the vehicle forward.
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //Apply force in forward direction.
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

        //Rotate the vehicle based on horizontal input
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        speed = playerRb.velocity.magnitude * 2.237f; // 3.6 for km/h
        speedometerText.SetText("Speed: " + Mathf.RoundToInt(speed) + "m/h");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
    }
}
