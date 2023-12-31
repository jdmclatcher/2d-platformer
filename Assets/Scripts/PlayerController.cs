﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject ninjaStar;

	public float shotDelay;
	private float shotDelayCounter;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	private Rigidbody2D myrigidbody2D;

	public bool onLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	public AudioSource jumpSoundEffect;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		gravityStore = GetComponent<Rigidbody2D>().gravityScale;

	}

	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}



	// Update is called once per frame
	void Update () {

		if (grounded)
			doubleJumped = false;

		anim.SetBool ("Grounded", grounded);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown("Jump") && grounded)
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump();
		}

		if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded) 
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump();
			doubleJumped = true;
		}

		//moveVelocity = 0f;

		//moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");
		Move (Input.GetAxisRaw ("Horizontal"));

#endif

		if (knockbackCount <= 0) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		} else {
			if (knockFromRight)
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-knockback, knockback);
			if(!knockFromRight)
				GetComponent<Rigidbody2D>().velocity = new Vector2 (knockback, knockback);

			knockbackCount -= Time.deltaTime;
		}

		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));


		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown ("Fire1")) 
		{
			//Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			FireStar();
			shotDelayCounter = shotDelay;
		}

		if (Input.GetButton("Fire1"))
		{
			shotDelayCounter -= Time.deltaTime;

			if(shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				//Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
				FireStar();
			}
		}

		if (anim.GetBool("Sword"))
		{
			//anim.SetBool("Sword", false);
			ResetSword();
		}

		if (Input.GetButtonDown("Fire2")) 
		{
			//anim.SetBool ("Sword", true);
			Sword();
		}

#endif

		if (onLadder) 
		{
			GetComponent<Rigidbody2D>().gravityScale = 0f;

			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");

			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, climbVelocity);
		}
		
		if (!onLadder) 
		{
			GetComponent<Rigidbody2D>().gravityScale = gravityStore;
		}	
	
	
	}

	public void Move(float moveInput)
	{
		moveVelocity = moveSpeed * moveInput;
	}


	public void FireStar()
	{
		Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
	}

	public void Sword()
	{
		anim.SetBool ("Sword", true);
	}

	public void ResetSword ()
	{
		anim.SetBool("Sword", false);
	}

	public void Jump()
	{
		//GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

		if (grounded)
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			//Jump();
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);



		}

		if (!doubleJumped && !grounded) 
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			//Jump();
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			doubleJumped = true;


		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = null;
		}
	}


}
