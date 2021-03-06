﻿using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour
{
	public Rigidbody2D backgroundProp;		// The prop to be instantiated.
	public float leftSpawnPosX = -12;				// The x coordinate of position if it's instantiated on the left.
	public float rightSpawnPosX = 12;			// The x coordinate of position if it's instantiated on the right.
	public float minSpawnPosY = 0;				// The lowest possible y coordinate of position.
	public float maxSpawnPosY = 10;				// The highest possible y coordinate of position.
	public float minTimeBetweenSpawns = 0;		// The shortest possible time between spawns.
	public float maxTimeBetweenSpawns = 10;		// The longest possible time between spawns.
	public float minSpeed = 5;					// The lowest possible speed of the prop.
	public float maxSpeed = 15;					// The highest possible speeed of the prop.

	void Start ()
	{
		// Set the random seed so it's not the same each game.
		Random.seed = System.DateTime.Today.Millisecond;

		// Start the Spawn coroutine.
		StartCoroutine("Spawn");
	}


	IEnumerator Spawn ()
	{
		// Create a random wait time before the prop is instantiated.
		float waitTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);

		// Wait for the designated period.
		yield return new WaitForSeconds(waitTime);

		// Randomly decide whether the prop should face left or right.
		bool facingLeft = Random.Range(0,2) == 0;

		// If the prop is facing left, it should start on the right hand side, otherwise it should start on the left.
		float posX = facingLeft ? rightSpawnPosX : leftSpawnPosX;

		// Create a random y coordinate for the prop.
		float posY = Random.Range(minSpawnPosY, maxSpawnPosY);

		// Set the position the prop should spawn at.
		Vector3 spawnPos = new Vector3(transform.position.x + posX, posY, transform.position.z);



		// Instantiate the prop at the desired position.
		Rigidbody2D propInstance = Instantiate(backgroundProp, spawnPos, Quaternion.identity) as Rigidbody2D;

		// Restart the coroutine to spawn another prop.
		StartCoroutine(Spawn());

		// While the prop exists...
		while(propInstance != null)
		{
			// ... and if it's facing left...
			if(facingLeft)
			{
				// ... and if it's beyond the left spawn position...
				if(propInstance.transform.position.x < leftSpawnPosX - 0.5f)
					// ... destroy the prop.
					Destroy(propInstance.gameObject);
			}
			else
			{
				// Otherwise, if the prop is facing right and it's beyond the right spawn position...
				if(propInstance.transform.position.x > rightSpawnPosX + 0.5f)
					// ... destroy the prop.
					Destroy(propInstance.gameObject);
			}

			// Return to this point after the next update.
			yield return null;
		}
	}
}
