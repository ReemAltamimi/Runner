using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public EndLevel endLevelTrigger;
    public Sprite openDoorSprite;
	// Use this for initialization
	void Start () {
        if (endLevelTrigger != null)
        {
            endLevelTrigger.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("missing end level trigger on door");
        }
	}


    public void Open() {
        if (endLevelTrigger != null)
        {
            endLevelTrigger.gameObject.SetActive(true);
        }

        if (openDoorSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = openDoorSprite;
        }
    }
}
