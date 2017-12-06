﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static PlayerController playerInstance;

	public float speed;

	Rigidbody myRB;
	public Transform emitter;
	public Rigidbody bullet;

    public float bShootCooldown;
    public float shootCooldown;

    public int direction;

    public GameObject heart1, heart2, heart3;
    public static int health;
    public float IeFrames = 0.3f;

    public Image damageImage;
    public bool damaged;

    public bool ImmuneToDamage;

    public Color screenFlash = new Color(1.0f, 0f, 0f, 0.1f);

    public PauseScript UIScript;



    void Start()
	{
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        playerInstance = this;
        direction = 1;
		myRB = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        if(health > 3)
        {
            health = 3;
        }

        if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && shootCooldown < Time.deltaTime)
        {
            Instantiate(bullet, emitter.position, Quaternion.identity);
            shootCooldown = bShootCooldown;
        }

        //Debug Testing
        if(Input.GetKeyDown(KeyCode.Z) && !ImmuneToDamage)
        {
            TakeDamage(1);
            Debug.Log(health);
        }

        if (!damaged)
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, IeFrames * Time.deltaTime);
        }

        SetHealth();
    }

    // Update is called once per frame
    void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            myRB.rotation = Quaternion.Euler(0, 0, 0);
            direction = 1;
        }
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            myRB.rotation = Quaternion.Euler(0, 180, 0);
            direction = -1;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        myRB.velocity = movement * speed;
    }

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemyBullet" && !ImmuneToDamage)
		{
            TakeDamage(1);
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
		}
	}

    public int GetDirection()
    {
        return direction;
    }

    public void SetHealth()
    {
        switch(health)
        {
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                
                UIScript.GameOver();
                break;
        }
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        StartCoroutine(InvisibilityFrames());
        health -= amount;
        DamageFlash();
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

}
