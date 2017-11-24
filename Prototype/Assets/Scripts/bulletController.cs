using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

    public int projDirection;
	public float speed;

	// Use this for initialization
	void Start () {
        projDirection = PlayerController.playerInstance.GetDirection();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(projDirection * speed, 0.0f, 0.0f);

        Destroy(gameObject, 2.0f);
	}

	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.tag == "enemy")
		{
			Destroy (collision.gameObject);
			Destroy (gameObject);
		}

		if (collision.gameObject.tag == "shield")
		{
			Destroy (gameObject);
		}
	}
}
