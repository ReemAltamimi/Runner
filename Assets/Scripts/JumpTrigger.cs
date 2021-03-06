﻿using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class JumpTrigger : MonoBehaviour {

    public float jumpPower = 10;
    public float cooldownTime = 2;
    private float coolDown = 0;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.GetComponent<PlayerControl>();
        if (player != null && coolDown <= 0)
        {
            player.DoJump(jumpPower);
            var audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    public void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

}
