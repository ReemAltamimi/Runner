using UnityEngine;
using System.Collections;

public class SpawnStar : MonoBehaviour {

    public Transform[] starSpawns;
    public GameObject star; 

	// Use this for initialization
	void Start ()
    {
        Spawn();
	
	}
	
	void Spawn()
    {
        //fill the starspawn
        for (int i = 0; i<starSpawns.Length; i++)
        {
            int starFlip = Random.Range(0, 2);
            if (starFlip > 0)
                Instantiate(star, starSpawns[i].position, Quaternion.identity);
        }
    }
}
