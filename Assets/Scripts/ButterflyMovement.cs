using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMovement : MonoBehaviour
{

    float rand1; //random number for direction change
    float rand2; //random number for direction change
    float rand3; //random number for direction change
    Vector3 InitialPosition; //Stores the first position of butterfly
    Vector3 DistanceFromInitialPoint; //Stores the distance from First Position on each frame
    public float MaximumAllowedRadius; //Maximum  Distance after which butterfly stops
    public float ButterflyMaxSpeed; //Maximum Speed of the fly


    private Vector3 start;
    private Vector3 des;
    private float fraction = 0;


    // Use this for initialization
    void Start ()
    {

        start = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Invoke("DirectionChange", 0.0f);
        Invoke("AnimationStart", Random.Range(0,1.0f));  //To make the fly look different, we play animation randomly
        InitialPosition = gameObject.transform.position; //stores initial position
    }
	
	// Update is called once per frame
	void Update ()
    {
        DistanceFromInitialPoint = (gameObject.transform.position - InitialPosition); //Distance from start point calculation
        if (DistanceFromInitialPoint.magnitude> MaximumAllowedRadius) //If the distance is greater than maximum allowed distance, then fly stops
        {
            //This needs to filled with code to bring the butterfly back in range
            float step = 0.02f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, start, step); //brings the butterfly back in range

        }
        else //give random velocity to the fly when the butterfly is in range
        {
                gameObject.transform.position += new Vector3(rand1 * ButterflyMaxSpeed, rand2 * ButterflyMaxSpeed, rand3 * ButterflyMaxSpeed);
        }

    }

    void DirectionChange() //function used for setting random directions
    {
        if (Random.Range(0.0f, 1.0f) > 0.5f)
            rand1 = -1;
        else rand1 = 1;

        if (Random.Range(0.0f, 1.0f) > 0.5f)
            rand2 = -1;
        else rand2 = 1;

        if (Random.Range(0.0f, 1.0f) > 0.5f)
            rand3 = -1;
        else rand3 = 1;

        Invoke("DirectionChange", 3.0f); //It calls itself so that we change the direction of fly after every 3 seconds
    }
    void AnimationStart()
    {
        gameObject.GetComponent<Animation>().Play(); //Starts animation
    }

}
