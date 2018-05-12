using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButterFly : MonoBehaviour {

    public GameObject ButterflyRef;
	// Use this for initialization
	void Start () {
        StartCoroutine(Coroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(6);
        Instantiate(ButterflyRef, gameObject.transform);
        StartCoroutine(Coroutine());
    }
}
