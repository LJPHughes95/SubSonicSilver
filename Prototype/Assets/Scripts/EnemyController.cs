using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Vector3 speed;

	Rigidbody enemyRB;

	public Transform emitter;
	public Rigidbody bullet;
	public float shootTime;

	float timer;
	float move;

	public bool harder;

	float timer2;
	private float multiplier;

	// Use this for initialization
	void Start () {
		speed = new Vector3 (8, 4, 0);
		enemyRB = GetComponent<Rigidbody> ();
		move = 3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		timer += Time.deltaTime;
		if (timer > move || transform.position.y > 13 || transform.position.y < -13) 
		{
			changeDirection ();
			timer = 0;
			move = 6;
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

		timer += Time.deltaTime;
		if (timer > shootTime)
		{
			Instantiate (bullet, emitter.position, Quaternion.identity);
			timer = 0;
		}
	}

	void onCollisionEnter (Collider col)
	{
		if (col.gameObject.tag == "pBullet") {
			if (harder == true) {
				Score.score += 150;
			} 
			else
			{
				Score.score = 100;
			}
		}
	}

	void changeDirection()
	{
		speed.y *= -1;
	}
}
