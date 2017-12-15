using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTurret : MonoBehaviour {

	public Transform emitter;

	public Rigidbody bullet;

	public int health;

	public float fireRate;

	float timer;
	int i;

	// Use this for initialization
	void Start () {
		health = 2;
		i = 0;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > fireRate)
		{
			Instantiate (bullet, emitter.position, Quaternion.identity);
			timer = 0;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "pBullet") {
			if (health == 0) {
				Destroy (gameObject);
				BossController.baseBossHealth -= 0.1f;
			} else {
				health--;
				Invoke ("hit", 0.2f);
				BossController.baseBossHealth -= 0.1f;
				GetComponent<MeshRenderer> ().enabled = false;
			}
		}
	}

	public void hit()
	{
		GetComponent<MeshRenderer> ().enabled = false;
		Invoke ("reset", 0.2f);
	}

	public void reset()
	{
		if (i < 2) {
			GetComponent<MeshRenderer> ().enabled = true;
			i += 1;
			Invoke ("hit", 0.2f);
		} else {
			GetComponent<MeshRenderer> ().enabled = true;
			i = 0;
			GetComponent<MeshRenderer> ().enabled = true;
		}
	}
}
