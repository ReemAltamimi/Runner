using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionScene : MonoBehaviour {

    public Button startText;

	// Use this for initialization
	void Start ()
    {
        startText = startText.GetComponent<Button>();
	}
	
	public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
