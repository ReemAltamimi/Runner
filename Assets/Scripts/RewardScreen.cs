using UnityEngine;
using System.Collections;

public class RewardScreen : MonoBehaviour {

    private static string nextLevel;

    public static void SetNextLevel(string next)
    {
        nextLevel = next;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if (!string.IsNullOrEmpty(nextLevel))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
            }
            else
            {
                Debug.LogWarning("No next level");
            }
        }
	}
}
