using UnityEngine;
using System.Collections;

public class LevelProgress : MonoBehaviour {

    public int starsNeededForKey = 10;


    private int starCount = 0;
    private Key key;
    private Door door;
    private Score score;

    public void Start()
    {
        key = FindObjectOfType<Key>();
        if (key != null)
        {
            key.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Missing key");
        }

        door = FindObjectOfType<Door>();
        if (door == null)
        {
            Debug.LogError("Missing door");
        }

        score = FindObjectOfType<Score>();
        if (score == null)
        {
            Debug.LogError("Missing score");
        }
    }


    public void onCollectStar() {
        starCount++;
        if (score != null)
        {
            score.score++;
        }
        if (starCount >= starsNeededForKey && key != null)
        {
            key.gameObject.SetActive(true);
        }
        
    }

    public void onCollectKey() {
        if (door != null)
        {
            door.Open();
        }
    }
}
