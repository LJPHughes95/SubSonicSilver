using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

	public float speed;
	
	Rigidbody bossRB;

	public Transform player;
	Vector3 offset;
	
	public static int health;

	public bool immune;
	
	float timer;
	float i;

	// Use this for initialization
	void Start () {
		health = 15;
		speed = 5;
		bossRB = GetComponent<Rigidbody> ();
		offset = transform.position - player.position;
		offset.y = 0;
		offset.z = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (player.position.x + offset.x, transform.position.y, transform.position.z);

		if(health > 5)
        {
            health = 5;
        }
		
		if (bossRB.position.y <= -14 && speed < 0)
		{
			changeDirection ();
		}
		if (bossRB.position.y >= 0 && speed > 0)
		{
			changeDirection ();
		}

		bossRB.velocity = new Vector3 (0, speed, 0);

	
	}
		
	void changeDirection()
	{
		speed *= -1;
	}
	
	 public void TakeDamage(int amount)
    {
        health -= amount;
    }

	void OnCollisionEnter(Collision other)
	{
				health--;
				Invoke ("hit", 0.2f);
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
		}
	}
}
