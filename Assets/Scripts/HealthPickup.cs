﻿using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int healthToGive;

	public AudioSource pickupSound;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null)
			return;

		HealthManager.HurtPlayer (-healthToGive);
		
		pickupSound.Play();

		Destroy (gameObject);
	}


}
