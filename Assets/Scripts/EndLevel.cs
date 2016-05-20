using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

    public string nextLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        print("entered the trigger");
        if (other.gameObject.tag == "Player")
        {
            RewardScreen.SetNextLevel(nextLevel);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Reward");
        }
    }
}
