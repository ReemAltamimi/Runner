using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public float normalizedTime = 0;
    public float speed = 1;
	// Use this for initialization
	void Start () {
        var animator = GetComponent<Animator>();
        animator.speed = speed;
        animator.Play("platformsMoving", 0, normalizedTime);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
