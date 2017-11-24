using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour {

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "pBullet")
		{
			Destroy (collision.gameObject);
		}
	}
}
