using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

	public float speed;

	Rigidbody bullet;

	BoxCollider test;

	public GameObject ExplosionGo;
	public GameObject ExplosionGo2;

	// Use this for initialization
	void Start () {
		speed = 50f;
		bullet = GetComponent<Rigidbody> ();
		test = GetComponent<BoxCollider> ();
		test.enabled = false;
		Invoke ("collision", 0.1f);
	}

	void collision()
	{
		test.enabled = true;
	}

	// Update is called once per frame
	void FixedUpdate () {

		bullet.velocity = new Vector3( speed, 0, 0);
		Destroy(gameObject, 2.0f);
	}

	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.tag == "enemy") {
			PlayExplosion();
			Destroy (collision.gameObject);
			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "Boss" && BossController.health <= 0){
			PlayExplosion2();
			Destroy (collision.gameObject);
			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "turret" || collision.gameObject.tag == "Boss")
		{
			PlayExplosion();
			Destroy (gameObject);
		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate(ExplosionGo);
		explosion.transform.position = transform.position;
	}

	void PlayExplosion2()
	{
		GameObject explosion = (GameObject)Instantiate(ExplosionGo2);
		explosion.transform.position = transform.position;
	}
}
