using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubbles : MonoBehaviour
{
    public GameObject BubblePrefabRef; //Bubble Prefab Reference
    bool StrawOccupied; //boolean to keep track if our bubble blowing straw is occupied with a bubble

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    
    void Spawn()
    {
        if (Input.GetKey("left shift"))
        {
            StrawOccupied = true;
            Instantiate(BubblePrefabRef, gameObject.transform.position, gameObject.transform.rotation);
        }
        StrawOccupied = false;
    }
}
