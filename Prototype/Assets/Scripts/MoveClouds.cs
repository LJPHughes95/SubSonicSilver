using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour {

	public float speed;

	Rigidbody CRB;

	Vector3 spawn;

	Vector3 target;

	// Use this for initialization
	void Start () {
		speed = -5;
		CRB = GetComponent<Rigidbody> ();
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
}

