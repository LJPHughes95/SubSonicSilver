using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenExit : MonoBehaviour {

	void onTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);
	}

	public Vector3 returnPosition()
	{
		return transform.position;
	}
}
