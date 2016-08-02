using UnityEngine;
using System.Collections;

public class LevelProgress : MonoBehaviour {

    public int starsNeededForKey = 10;
    public int oneStar = 15;
    public int twoStars = 25;
    public int threeStars = 35;

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
        Hearts.Reset();
        Hearts.SetThreshholds(new[] { oneStar, twoStars, threeStars });
    }


    public void onCollectStar() {
        starCount++;
        if (score != null)
        {
            score.score++;
            Hearts.SetTotal(starCount);
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
