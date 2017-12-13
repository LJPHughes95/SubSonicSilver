using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

	public float speed;
	
	Rigidbody bossRB;
	
	public Transform emitter;
	public Transform emitter2;
	
	public Rigidbody bullet;
	
	public static int health;

    public bool ImmuneToDamage;
	
	public float minShootTime1;
	public float maxShootTIme1;
	
	public float minShootTime2;
	public float maxShootTime2;
	
	public float IeFrames = 0.3f;
	
	public Color screenFlash = new Color(0.8f, 0.4f, 0f, 1f);
	
	float timer;
	float i;

	// Use this for initialization
	void Start () {
        health = 1.0f;
        bossCurrentHealth = health;
        bossHealthBar.fillAmount = bossCurrentHealth;
		speed = 15;
		bossRB = GetComponent<Rigidbody> ();
	}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(0.2f);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (player.position.x + offset.x, transform.position.y, transform.position.z);

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
		if (bossRB.position.y >= 14 && speed > 0)
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
	
	public void DamageFlash()
    {
        if(damaged)
        {
            damageImage.color = screenFlash;
        }
        if(damaged && health == 0)
        {
            damageImage.color = Color.clear;
        }
        damaged = false;
    }
	
	 public IEnumerator InvisibilityFrames()
    {
        damaged = true;
        ImmuneToDamage = true;
        yield return new WaitForSeconds(IeFrames);
        damaged = false;
        ImmuneToDamage = false;

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
			GetComponent<MeshCollider> ().enabled = true;
		}
	}
}
