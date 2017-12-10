using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	void OnTriggerEnter (Collision col)
	{
		transform.position = new Vector3 (transform.position.x + Random.Range (80, 120), transform.position.y, transform.position.z);
	}

}
