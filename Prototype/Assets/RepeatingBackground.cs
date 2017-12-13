using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	public Rigidbody other;
	public float offset;

	public BoxCollider bG;

	private Rigidbody BG;

	public float speed;

	// Use this for initialization
	void Start () {
		
		bG = GetComponent<BoxCollider> ();
		BG = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		BG.velocity = new Vector3 (speed, 0, 0);

		if (other.position.x - offset > (transform.position.x + (bG.size.x* transform.localScale.x)))
		{
			RepositionBackground();
		}
	}

	private void RepositionBackground()
	{
		transform.position += new Vector3((bG.size.x* transform.localScale.x) * 2.0f, 0, 0);
	}
}
