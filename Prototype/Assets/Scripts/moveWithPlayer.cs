using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithPlayer : MonoBehaviour {

	public Transform player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = player.position - transform.position;
		offset.y = 0;
		offset.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.position - offset;
	}
}
