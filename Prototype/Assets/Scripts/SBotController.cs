using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBotController : MonoBehaviour {

	Rigidbody enemyRB;

	public Vector3 speed;
	private float multiplier;

	static Transform player;

	// Use this for initialization
	void Start () {
		speed = new Vector3 (8, 0, 0);
		enemyRB = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		//player = PlayerController.test;

		 multiplier = 0.75f;

		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			multiplier = 1.0f;
		}
		if(Input.GetAxisRaw("Horizontal") < 0)
		{
			multiplier = 0.5f;
		}

		enemyRB.velocity = speed * multiplier;
	}

	void onCollisionEnter (Collider col)
	{
		if (col.gameObject.tag == "pBullet") {
			Score.score += 200;
		}
	}
}
	
