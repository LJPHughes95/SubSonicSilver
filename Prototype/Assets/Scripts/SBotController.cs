using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBotController : MonoBehaviour {

	public float speed;

	Rigidbody enemyRB;

	// Use this for initialization
	void Start () {
		speed = 15;
		enemyRB = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (enemyRB.position.y <= 4 && speed < 0)
		{
			changeDirection ();
		}
		if (enemyRB.position.y >= 24 && speed > 0)
		{
			changeDirection ();
		}

		enemyRB.velocity = new Vector3 (0, speed, 0);
	}

	void changeDirection()
	{
		speed *= -1;
	}
}
	
