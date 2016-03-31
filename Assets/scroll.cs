using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

    public float speed = 0;

	
	// Update is called once per frame
	void Update ()
    {

        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);


    }
}
