using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            var progress = other.gameObject.GetComponent<LevelProgress>();
            if (progress != null)
            {
                progress.onCollectKey();
            }
            else
            {
                Debug.LogError("Missing Level Progress component on player");
            }
        }

    }

}
