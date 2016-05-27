using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System.Collections;

public class MainMenu : MonoBehaviour {
    public int unlocked = 3;
    List<Button> m_buttons = new List<Button>();
	// Use this for initialization
	void Start () {
        m_buttons.AddRange(GetComponentsInChildren<Button>());
        m_buttons.Sort((b1, b2) => { return string.Compare(b1.name, b2.name); });
        Application.ExternalCall("onMenuReady");

#if UNITY_EDITOR
        SetUnlocked(unlocked);
#endif


    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void SetUnlocked(int levels)
    {
        Debug.Log("Unlocking " + levels + " levels");
        for (int idx = 0; idx < m_buttons.Count; idx++)
        {
            if (idx >= levels)
            {
                m_buttons[idx].interactable = false;
            }
        }
    }


}
