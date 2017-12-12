using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

    public int projDirection;
	public float speed;
    Rigidbody bullet;

	// Use this for initialization
	void Start () {
        projDirection = PlayerController.playerInstance.GetDirection();
        speed = 50f;
		bullet = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(projDirection * speed, 0.0f, 0.0f);       
		bullet.velocity = new Vector3( speed, 0, 0);
        Destroy(gameObject, 2.0f);
	}

	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.tag == "enemy") {
			Destroy (collision.gameObject);
			Destroy (gameObject);
		}
	}
}
