using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

	public float speed;

	Rigidbody bullet;

	public GameObject ExplosionGo;

	// Use this for initialization
	void Start () {
		speed = 50f;
		bullet = GetComponent<Rigidbody> ();
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
			PlayExplosion();
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
}
