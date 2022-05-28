using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;

    // wait before firing again:
    public float fireRate = .25f;

    // how far the raycast will cast in our scene:
    public float weaponRange = 50f;

    // apply force to rigidbodies:
    public float hitforce = 100f;

    // laserline will begin at end of gun end:
    public Transform gunEnd;

    private Camera fpsCam;

    // how long we will display the shot on screen:
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    private AudioSource gunAudio;

    // draws a straight line between two points in scene:
    private LineRenderer laserLine;

    // will hold the time at which the player will be allowed to fire again after firing:
    private float nextFire;


    void Start()
    {
        // set up our component references:
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();

        // because the camera is not attached to the gun gameobject which has this script, but its parent, we use GetComponentInParent:
        fpsCam = GetComponentInParent<Camera>();

    }


    void Update()
    {
        
    }
}
