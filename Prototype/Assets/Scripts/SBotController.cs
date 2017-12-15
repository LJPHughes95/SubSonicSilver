using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBotController : MonoBehaviour {

	Rigidbody enemyRB;

	public Vector3 speed;
	private float multiplier;
	float timer;
	float move;

	static Transform player;

	// Use this for initialization
	void Start () {
		speed = new Vector3 (8, 4, 0);
		move = 5;
		enemyRB = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		timer += Time.deltaTime;
		if (timer > move || transform.position.y > 13 || transform.position.y < -13) 
		{
			changeDirection ();
			timer = 0;
			move = 10;
		}


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

	void changeDirection()
	{
		speed.y *= -1;
	}
}
	
