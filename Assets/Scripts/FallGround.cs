using UnityEngine;
using System.Collections;

public class FallGround : MonoBehaviour {

    public float FallDelay = 1f;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
    //when player steps on the ground it will fall 
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Invoke ("Fall", FallDelay); 
    }

    void Fall()
    {
        rb2d.isKinematic = false;
        StartCoroutine(FallCoroutine());
    }

    IEnumerator FallCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
