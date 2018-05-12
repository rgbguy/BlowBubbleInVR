using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormBubblesOnBlowing : MonoBehaviour {

    bool StrickOccupied;
    bool Done;
    public GameObject BubblePrefabRef;
    GameObject FormedBubble;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("space"))
        {
            if (!Done)
            {
                Done = true;
                FormBubble();
            }
        }
    }

    void FormBubble() //forms the bubble and doesnt allow the stick to form another bubble until fly is caught
    {

        FormedBubble =  Instantiate(BubblePrefabRef, gameObject.transform.position, gameObject.transform.rotation);
        FormedBubble.GetComponent<AttachToBubble>().StickReference = gameObject;       
    }

    public void UnlockStick()//allows stick to form bubbles again
    {
        Done = false;
    }
}
