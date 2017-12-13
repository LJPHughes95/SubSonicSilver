using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

	public float speed;
	
	Rigidbody bossRB;

	public Transform player;
	Transform offset;
	
	public static int health;

	public bool immune;
	
	float timer;
	float i;

	// Use this for initialization
	void Start () {
		health = 5;
		speed = 5;
		bossRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
