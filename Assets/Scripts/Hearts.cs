﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Hearts : MonoBehaviour {

    public static void Reset()
    {
        ms_thressholds = new int[] { 10, 20, 30};
        total = 0;
    }

    public static void SetThreshholds(int[] threshholds)
    {
        Debug.Assert(threshholds.Length == 3);
        ms_thressholds = threshholds;
    }

    public static void SetTotal(int value)
    {
        total = value;
    }

    public static int GetStarCount() { return total; }
    public static int GetHeartCount()
    {
        int heartCount = 0;
        while (heartCount < ms_thressholds.Length && ms_thressholds[heartCount] <= total)
        {
            heartCount++;
        }
        Debug.Log("hearts" + heartCount);
        return heartCount;
    }


    private static int[] ms_thressholds = { 10, 20, 30};
    private static int total = 30;
    
    public SpriteRenderer[] hearts;
    public float coinTick = 0.2f;
    public Color enabledColor = Color.white;
    public Color disabledColor = Color.grey;
    public Text coinCounter;
    private int count = 0;
    private float timer = 0;
	// Use this for initialization
	void Start () {
	    // set all hearts inactive.
        foreach (var heart in hearts)
        {
            heart.color = disabledColor;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (count < total)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                count++;
                for (int i = 0; i < ms_thressholds.Length; i++)
                {
                    if (count == ms_thressholds[i])
                    {
                        SetHeartActive(i);
                    }
                }
                timer = coinTick;
                coinCounter.text = count.ToString(); 
            }
        }
    }


    void SetHeartActive(int heartIdx)
    {
        hearts[heartIdx].color = enabledColor;
    }
}
