using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopPlayer : MonoBehaviour {

	public Transform player;

	public float offset;

	// Use this for initialization
	void Start () {
		 offset = player.position.x - transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player.position.x - transform.position.x > offset)
		{
			transform.position = new Vector3 ((player.position.x - offset), transform.position.y, transform.position.z);
		}
	}
}
