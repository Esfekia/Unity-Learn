using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2 : MonoBehaviour
{
    public GameObject player2;
    private Vector3 offset = new Vector3(0, 2, 0.5f);
    // Start is called before the first frame update
   
    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding the player's position
        transform.position = player2.transform.position + offset;
    }
}
