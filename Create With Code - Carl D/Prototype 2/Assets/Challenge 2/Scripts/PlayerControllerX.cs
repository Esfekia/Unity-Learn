using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogOut = 0.5f;
    public float dogIn = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > dogIn)
        {
            dogIn = Time.time + dogOut;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
