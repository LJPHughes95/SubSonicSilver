using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour {

	public float speed;

	Rigidbody CRB;

	// Use this for initialization
	void Start () {
		speed = -5;
		CRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CRB.velocity = new Vector3 (speed, 0, 0);
	}
}
