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
        // check if fire button is pressed and if enough time passed since last fire.
        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            // we need to set the origin of the ray in relation to the camera's center.
            // take a position relative to the camera and convert it to world space.
            // viewport is the area we see on screen an is limited to (0,0) and (1,1)
            // by positioning it at (0.5), (0.5) we center it exactly in the middle of the "screen"
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            // determine if the ray has hit a gameobject with a collider attached and store it in variable:
            RaycastHit hit;

            // determine start and end positions for laser line when player fires:
            // establish initial position of the line and target.
            laserLine.SetPosition(0, gunEnd.position);

            // we will use physics.raycast to cast our ray
            // we will use the result of raycast to determine where the end point of our laserline will be
            // later we will also use it to apply physics forces to gameobjects it intersected and
            // to deal damage if it has health attached
            // physics.raycast returns a boolean


            // first the origin, then the dfirection.
            // using the out keyword allows us to store information from a function in addition to its return type
            // finally the weapon range

            if (Physics.Raycast(rayOrigin,fpsCam.transform.forward, out hit, weaponRange))
            // two possible positions for the end of our laser: the position of whatever we hit or nothing.
            {
                laserLine.SetPosition(1, hit.point);
            }
            else
            // 50 units away from origin, in the direction of our camera:
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
            // now the linerenderer will draw a line from the position of the gun end to the position that the player aimed at
            // using our raycast

            // (we add the line renderer component to the Gun gameobject and set its Gun End using editor)
        }    
        

    }

    // turn on and off our laser fire effect with a coroutine.
    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;

        // wait for 0.75 seconds before turning the laser line off:
        yield return shotDuration;
        laserLine.enabled = false;

    }
}
