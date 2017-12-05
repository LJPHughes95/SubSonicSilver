using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public static PlayerController playerInstance;

	public float speed;

	Rigidbody myRB;
	public Transform emitter;
	public Rigidbody bullet;

    public float bShootCooldown;
    public float shootCooldown;

    public int direction;

    void Start()
	{
        playerInstance = this;
        direction = 1;
		myRB = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && shootCooldown < Time.deltaTime)
        {
            Instantiate(bullet, emitter.position, Quaternion.identity);
            shootCooldown = bShootCooldown;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            myRB.rotation = Quaternion.Euler(0, 90, 0);
            direction = 1;
        }
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            myRB.rotation = Quaternion.Euler(0, 270, 0);
            direction = -1;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        myRB.velocity = movement * speed;

		if (transform.position.y >= 15) {
			transform.position = new Vector3 (transform.position.x, 15, transform.position.z);
		}
		if (transform.position.y <= -15)
		{
			transform.position = new Vector3 (transform.position.x, -10, transform.position.z);
		}

    }

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "enemy")
		{
			Destroy (collision.gameObject);
			Destroy (gameObject);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

    public int GetDirection()
    {
        return direction;
    }
}
