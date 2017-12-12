using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBotController : MonoBehaviour {

	Rigidbody enemyRB;

	public Vector3 speed;
	private float multiplier;

	// Use this for initialization
	void Start () {
		speed = 15;
		speed = new Vector3 (8, 0, 0);
		enemyRB = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		 multiplier = 0.75f;

		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			multiplier = 1.0f;
		}
		if(Input.GetAxisRaw("Horizontal") < 0)
		{
			multiplier = 0.5f;
		}
		enemyRB.velocity = new Vector3 (0, speed, 0);
	}

	void changeDirection()
	{
		speed *= -1;
		enemyRB.velocity = speed * multiplier;
	}
}
	
