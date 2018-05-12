using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll_Bubble : MonoBehaviour {

	// Use this for initialization
	void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
        PanTexture();// Function used to make the bubble texture move
	}

    bool PanTexture()
    {
        var scrollSpeed = 0.20; // Defines the scroll speeds
        var scrollSpeed2 = 0.10;
        var offset = Time.time * scrollSpeed; //Defines the offset to be added with time to the texture
        var offset2 = Time.time * scrollSpeed2;

        var Rend = GetComponent<Renderer>(); // gets the renderer component
        Rend.material.mainTextureOffset = new Vector2((float)offset2, (float)-offset); //sets the texture offset to make the bubble look realistic
        return true;
    }
}
