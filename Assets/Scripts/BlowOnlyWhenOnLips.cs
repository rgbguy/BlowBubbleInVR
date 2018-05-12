using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowOnlyWhenOnLips : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "lips")
        {
            gameObject.GetComponent<AudioRecorder>().NearLips = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "lips")
        {
            Debug.Log("Stick Outside Range");
            gameObject.GetComponent<AudioRecorder>().NearLips = false;
        }
    }
}
