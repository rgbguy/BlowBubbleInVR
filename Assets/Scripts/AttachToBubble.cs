using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToBubble : MonoBehaviour {

    GameObject flyReference;
    public GameObject StickReference;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetFlyPosition(flyReference);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fly") //checks if the object it collides has a tag burst
        {
            Debug.Log("Touched Fly");
            flyReference = other.gameObject;
            flyReference.GetComponent<ButterflyMovement>().enabled = false;
            //gameObject.GetComponent<BubbleSizeBehavior>().DetachAfterTime();
            //new WaitForSeconds(2);
            //StickReference.GetComponent<FormBubblesOnBlowing>().UnlockStick();
            //The stick should be unlocked on trigger pressed of controller
        }
    }

    void SetFlyPosition(GameObject fly)
    {
        if (fly) //null pointer check
        {
            fly.transform.position = gameObject.transform.position + new Vector3(0.0f, -0.008f, 0.0f);
        }  
    }
}
