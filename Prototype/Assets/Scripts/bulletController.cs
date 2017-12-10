using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

    public int projDirection;
	public int speed;
	Rigidbody bullet;

	// Use this for initialization
	void Start () {
		speed = 20;
		bullet = GetComponent<Rigidbody> ();
		Invoke ("scale", 0.2f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		bullet.velocity = new Vector3( speed, 0, 0);
        Destroy(gameObject, 4.0f);
	}

	void OnCollisionEnter (Collision collision)
	{
		GetComponent<BoxCollider> ().enabled = false;

		if (collision.gameObject.tag == "enemy") {
			Destroy (collision.gameObject);
			Destroy (gameObject);
		} 
		else 
		{
			Destroy (gameObject);
		}
	}

	void Collision ()
	{
		GetComponent<BoxCollider> ().enabled = true;
	}

	void scale()
	{
		transform.localScale = new Vector3 (1.5f, 1.5f, 2f);
	}
}
