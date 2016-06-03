using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    public string nextLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        print("entered the trigger");
        if (other.gameObject.tag == "Player")
        {
            RewardScreen.SetNextLevel(nextLevel);
            Application.ExternalCall("onLevelComplete", SceneManager.GetActiveScene().buildIndex, Hearts.GetStarCount(), Hearts.GetHeartCount());
            UnityEngine.SceneManagement.SceneManager.LoadScene("Reward");
        }
    }
}
