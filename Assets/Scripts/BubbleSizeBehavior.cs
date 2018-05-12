using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSizeBehavior : MonoBehaviour
{

    public bool Detached;
    Vector3 RandomVelocityAfterDetach;
    public float TimeToDetach;
    public GameObject[] BubbleReferences;
    bool neverDone;
	public GameObject BlowStick;


    // Use this for initialization
    void Start()
    {
        //Sets a random Velocity to detach the bubble
		Detached = false;
        neverDone = true;
        TimeToDetach = 3.0f;
        RandomVelocityAfterDetach = new Vector3(Random.Range(-0.005F, 0.005F), Random.Range(-0.005F, 0.005F), Random.Range(-0.005F, 0.005F));
        Invoke("DetachAfterTime", TimeToDetach);//Calls function DetachAfterTime after TimeToDetach Seconds
        //Invoke("ParticleEffectAndDie", Random.Range(4,8)); // To automatically destroy the bubble after sometime
    }

    // Update is called once per frame
    void Update()
    {
        if (!Detached)//if the bubble is not detached then allow size increasing
        {
          gameObject.transform.position = BlowStick.transform.position + new Vector3(0,0.015f,0);
          gameObject.transform.eulerAngles = BlowStick.transform.eulerAngles;

        }
        if (Detached)//if the bubble is detached, give it a random velocity
        {
            GetComponent<Rigidbody>().velocity += RandomVelocityAfterDetach;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "burst") //checks if the object it collides has a tag burst
        {
            ParticleEffectAndDie();
        }
    }

    void BurstOnSizeMax() //To burst the bubble if it reaches a maximum size
    {
        var Tr = GetComponent<Transform>(); //gets the size of the bubble
        if (Tr.localScale == new Vector3(3.0F, 3.0F, 3.0F)) //if the size is 3x of the original then bubble will burst
        {
            //Destroy(gameObject); //Destroys the object
        }
    }

    public void IncreaseSizeOnAction() //To increase size on key press
    {
        Debug.Log("Called");
        var Tr = GetComponent<Transform>();
            Tr.localScale += new Vector3(0.0005F, 0.0005F, 0.0005F);
            Debug.Log("Size Increasing");
    }

    public void DetachAfterTime()
    {
        Detached = true;
    }

    void DestroyActor()
    {
        Destroy(gameObject);
    }

    void ParticleEffectAndDie()
    {
        Debug.Log("Touched Object");
        gameObject.GetComponent<ParticleSystem>().Play(); //get particle to spawn on bursting
        if (neverDone)
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled; //Make mesh invisible as it touches wall
            neverDone = false;
        }
        gameObject.GetComponent<AudioSource>().Play(); //plays the sound when bubble bursts
        Invoke("DestroyActor", 2); //destroy after 2 seconds
    }
}
