using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;

	Rigidbody enemyRB;

	public Transform emitter;
	public Rigidbody bullet;

	public float minShootTime;
	public float maxShootTIme;

	float timer;
	float i;

	// Use this for initialization
	void Start () {
		speed = 15;
		enemyRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (enemyRB.position.y <= -14 && speed < 0)
		{
			changeDirection ();
		}
		if (enemyRB.position.y >= 14 && speed > 0)
		{
			changeDirection ();
		}

		enemyRB.velocity = new Vector3 (0, speed, 0);

		timer += Time.deltaTime;
		i = Random.Range (minShootTime, maxShootTIme);
		if (timer > i)
		{
			Instantiate (bullet, emitter.position, Quaternion.identity);
			timer = 0;
		}
	}
		
	void changeDirection()
	{
		speed *= -1;
	}
}
