using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanMotion : MonoBehaviour {

    public float SpeedofFan;


    bool reverse;

    // Use this for initialization
    void Start () {
        reverse = false;
        Invoke("ChangeDir", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (reverse)
        {
            gameObject.transform.Rotate(Vector3.right * Time.deltaTime * -SpeedofFan);
        }
        else
        {
            gameObject.transform.Rotate(Vector3.right * Time.deltaTime * SpeedofFan);
        }
    }

    void ChangeDir()
    {
        if (reverse)
        {
            reverse = false;
        }
        else
        {
            reverse = true;
        }
        Invoke("ChangeDir", 0.5f);
    }
}
