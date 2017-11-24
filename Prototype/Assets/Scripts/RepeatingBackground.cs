using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	public Rigidbody other;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (other.position.x > (transform.position.x + 48))
		{
			RepositionBackground();
		}
	}

	private void RepositionBackground()
	{
		transform.position += new Vector3(84, 0, 0);
	}
}
