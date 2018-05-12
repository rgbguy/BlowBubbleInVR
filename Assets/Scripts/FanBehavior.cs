using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBehavior : MonoBehaviour {

    public float ForceofFan;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bubble")
        {
            other.GetComponent<Rigidbody>().velocity += gameObject.transform.up * ForceofFan;
        }
        
    }

}
