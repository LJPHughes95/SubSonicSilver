﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ebulletController : MonoBehaviour {

	public int speed;
	Rigidbody bullet;

	// Use this for initialization
	void Start () {
		speed = -15;
		bullet = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		bullet.velocity = new Vector3( speed, 0, 0);
		Destroy (gameObject, 2.0f);
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//Destroy (collision.gameObject);
			Destroy (gameObject);
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

	}

}
