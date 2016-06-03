using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


using System.Collections;

public class MainMenu : MonoBehaviour {
    public int unlocked = 3;
    public int[] debugUnlockedHearts = { 1, 2, 0};
    List<Button> m_buttons = new List<Button>();
	// Use this for initialization
	void Start () {
        m_buttons.AddRange(GetComponentsInChildren<Button>());
        m_buttons.Sort((b1, b2) => { return string.Compare(b1.name, b2.name); });
        Application.ExternalCall("onMenuReady");

#if UNITY_EDITOR
        SetUnlocked(unlocked);
        SetUnlockedHearts(debugUnlockedHearts);
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

    void SetUnlockedHearts(int[] hearts)
    {
        for (int buttonidx = 0; buttonidx < m_buttons.Count; buttonidx++)
        {
            // get all hearts
            var menuHearts = m_buttons[buttonidx].transform.GetComponentsInChildren<MenuHeart>();
            System.Array.Sort(menuHearts, (heart1, heart2) => { return (heart1.transform.position.x < heart2.transform.position.x)? -1: 1; });
            if (buttonidx < hearts.Length && m_buttons[buttonidx].interactable)
            {
                for (int i = 0; i < hearts[buttonidx]; i++)
                {
                    if (i < menuHearts.Length)
                    {
                        menuHearts[i].Enable();
                    }
                }
            }
            else
            {
                // for locked or incomplete : fade
                for (int i = 0; i < menuHearts.Length; i++)
                {
                    menuHearts[i].Fade();
                }
            }
        }
    }
}
