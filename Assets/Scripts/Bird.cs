using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    public float speed = 10;

    private float dir = 1;

	// Use this for initialization
	void Start () {
        var cam = Camera.main;
        dir = Mathf.Sign(transform.position.x - cam.transform.position.x);
        
        transform.localScale = new Vector3(dir, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * dir * speed;
        
    }
}
