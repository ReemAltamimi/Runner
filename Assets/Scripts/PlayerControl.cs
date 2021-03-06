﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public enum Speed {
        Slow,
        Medium,
        Fast
    }

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// jump trigger.
    private int jumpLevel = 0;

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;             // The fastest the player can travel in the x axis.
    public float slowSpeed = 5f;             // The fastest the player can travel in the x axis when slowed.
    public float fastSpeed = 8f;             // The fastest the player can travel in the x axis at medium pace.
    public float mediumSpeed = 8f;             // The fastest the player can travel in the x axis at max pace.
    public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float[] jumpForce = { 1000f, 600f };			// Amount of force added when the player jumps.
	public AudioClip[] taunts;				// Array of clips for when the player taunts.
    public AudioClip timeWarning;
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.
    public int maxJump = 2;
    public GUIText stepsPrefab;
    public GUIText timePrefab;
    public GUIText scorePrefab;
    public Transform healthBarPrefab;
    public Speed debugSpeed = Speed.Medium;
    public float heartbeatTime = 30;
    private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
    private float direction = 1;
    private GUIText stepsText;
    private GUIText timeText;
    private GUIText scoreText;
    private Transform healthBar;
    private bool doHeartbeat = false;
    private float heartbeatTimeRemaining = 30.0f;
    private static float playTimeRemaining = 600;
    private int playTimeRemainingSeconds;

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
        if (scorePrefab)
        {
            scoreText = Instantiate(scorePrefab);

        }

    }

    public void Start()
    {
        var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        if (healthBarPrefab)
        {
            healthBar = Instantiate(healthBarPrefab);
            healthBar.transform.parent = Camera.main.transform;
            healthBar.transform.localPosition = new Vector3(0, 18, 2);
        }

        if (scene.name.ToLower().StartsWith("level"))
            doHeartbeat = true;

        if (Application.isEditor)
        {
            SetSteps(11552);
            SetTime(600);
            switch (debugSpeed)
            {
                case Speed.Slow:
                    SetupSlow();
                    break;
                case Speed.Medium:
                    SetupMedium();
                    break;
                case Speed.Fast:
                    SetupFast();
                    break;
            }
        }
        else
        {
            Application.ExternalCall("onPlayerReady", scene.name);
        }
        
        
    }

    public void SetupSlow()
    {
        print("hero is slowed");
        maxSpeed = slowSpeed;
        maxJump = 0;
    }


    public void SetupMedium()
    {
        print("hero is medium");
        maxSpeed = mediumSpeed;
        maxJump = 1;
    }


    public void SetupFast()
    {
        print("hero is fast");
        maxSpeed = fastSpeed;
        maxJump = int.MaxValue;
    }

    public void SetSteps(int steps)
    {
        if (!stepsText)
        {
            if (stepsPrefab)
            {
                stepsText = Instantiate(stepsPrefab);

            }

        }

        if (stepsText)
        {
            stepsText.text = "Steps:" + steps.ToString();
        }

        

    }

    public void SetTime(float time)
    {
        playTimeRemaining = time;

        if (!timeText)
        {
            if (timePrefab)
            {
                timeText = Instantiate(timePrefab);

            }
        }

        if (timeText)
        {
            System.TimeSpan span = new System.TimeSpan(0, 0, (int)playTimeRemaining);
            timeText.text = "Time:" + playTimeRemaining.ToString(span.ToString());
        }

    }


    void Update()
	{
        var rigidBody = GetComponent<Rigidbody2D>();
        
        
        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump") && jumpLevel < maxJump)
        {
            jump = true;
        }

        if (transform.position.y < -500)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (doHeartbeat)
        {
            heartbeatTimeRemaining -= Time.deltaTime;
            playTimeRemaining -= Time.deltaTime;
            if (Mathf.FloorToInt(playTimeRemaining) != playTimeRemainingSeconds)
            {
                playTimeRemainingSeconds = Mathf.FloorToInt(playTimeRemaining);
               

                if (playTimeRemainingSeconds < 10 && timeWarning != null)
                {
                    GetComponent<AudioSource>().PlayOneShot(timeWarning);
                }
                if (playTimeRemainingSeconds >= 0)
                {
                    System.TimeSpan span = new System.TimeSpan(0, 0, playTimeRemainingSeconds);

                    timeText.text = "Time:" + Mathf.FloorToInt((float)span.TotalMinutes) + "-" + span.Seconds.ToString("00");
                }
                else
                {
                    Application.ExternalCall("onHeartbeat", 0);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("TimeEnd");
                }
            }
            if (heartbeatTimeRemaining < 0)
            {
                heartbeatTimeRemaining = Mathf.Min(heartbeatTime, Mathf.Max(0,playTimeRemaining));
                Application.ExternalCall("onHeartbeat", playTimeRemaining);
            }
        }
    }

    void OnDestroy()
    {
        if (doHeartbeat)
        {
            heartbeatTimeRemaining = Mathf.Min(heartbeatTime, Mathf.Max(0, playTimeRemaining));
            Application.ExternalCall("onHeartbeat", playTimeRemaining);
        }
    }

	void FixedUpdate ()
	{
        var rigidBody = GetComponent<Rigidbody2D>();
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f) {
            // Cache the horizontal input.
            direction = Mathf.Sign(Input.GetAxis("Horizontal"));
        }

        Vector2 raycast = groundCheck.localPosition;
        grounded = Physics2D.CircleCast(transform.position, 0.76f,  raycast.normalized, raycast.magnitude,  1 << LayerMask.NameToLayer("Ground"));

        float h = direction * 0.4f;

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        anim.SetFloat("Speed", Mathf.Abs(h));

        if (Mathf.Sign(direction) != Mathf.Sign(rigidBody.velocity.x)){
            rigidBody.velocity = new Vector2(Mathf.Sign(direction) * maxSpeed, rigidBody.velocity.y);
        }

        
        Debug.DrawLine(transform.position, groundCheck.position, grounded ? Color.green : Color.red);


		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(grounded && h * rigidBody.velocity.x < maxSpeed)
        {
            // ... add a force to the player.
            rigidBody.AddForce(Vector2.right * h * moveForce);
        }

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");

			// Play a random jump audio clip.
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

            // Add a vertical force to the player.
            float force = (jumpLevel < jumpForce.Length) ? jumpForce[jumpLevel] : jumpForce[jumpForce.Length-1];
            var rigidbody = GetComponent<Rigidbody2D>();
            Vector2 velocity = rigidbody.velocity;
            velocity.y = 0;
            rigidbody.velocity = velocity;
            rigidbody.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
            jumpLevel++;

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
        else
        {
            if (grounded && Mathf.Abs(rigidBody.velocity.y) < 0.1f)
            {
                jumpLevel = 0;
            }

        }
    }


    public void DoJump(float power)
    {
        if (jumpLevel == 0)
        {
            jumpLevel++;
        }
        var rigidbody = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody.velocity;
       
        velocity.y = power;
        rigidbody.velocity = velocity;

    }


    void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	public IEnumerator Taunt()
	{
		// Check the random chance of taunting.
		float tauntChance = Random.Range(0f, 100f);
		if(tauntChance > tauntProbability)
		{
			// Wait for tauntDelay number of seconds.
			yield return new WaitForSeconds(tauntDelay);

			// If there is no clip currently playing.
			if(!GetComponent<AudioSource>().isPlaying)
			{
				// Choose a random, but different taunt.
				tauntIndex = TauntRandom();

				// Play the new taunt.
				GetComponent<AudioSource>().clip = taunts[tauntIndex];
				GetComponent<AudioSource>().Play();
			}
		}
	}


	int TauntRandom()
	{
		// Choose a random index of the taunts array.
		int i = Random.Range(0, taunts.Length);

		// If it's the same as the previous taunt...
		if(i == tauntIndex)
			// ... try another random taunt.
			return TauntRandom();
		else
			// Otherwise return this index.
			return i;
	}
}
