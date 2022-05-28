using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViweer : MonoBehaviour
{
    // determine how far our line will travel into the scene
    public float weaponRange = 50f;

    private Camera fpsCam;

    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }


    void Update()
    {
        // calculate origin point for line then draw it using Debug.DrawRay
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);


    }
}
