using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position + offset;
		targetCamPos.y = transform.position.y;
		targetCamPos.z = transform.position.z;

		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
