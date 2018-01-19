using System.Collections;
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

    public static int health;
    public float IeFrames = 0.3f;

    public float shieldRegen;
    public float baseShieldRegen = 0.5f;

    public Image damageImage;
    public bool damaged;

    public float currentHealth;
    public float basePlayerHealth = 1;

    public float currentShield;
    public float basePlayerShield = 1;

    public bool ImmuneToDamage;

    public Color screenFlash = new Color(1.0f, 0f, 0f, 1f);

    public PauseScript UIScript;

    int i;

    public Text playerHealthText;
    public Text playerShieldText;

    public Image shieldBar;
    public Image healthBar;

    public bool shieldDepleted;



    void Start()
    {
        currentHealth = basePlayerHealth;
        currentShield = basePlayerShield;
        healthBar.fillAmount = currentHealth;
        shieldBar.fillAmount = currentShield;

        playerInstance = this;
        myRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        playerHealthText.text = "Health: " + currentHealth * 100;
        playerShieldText.text = "Shield: " + currentShield * 100;

        if(currentShield < basePlayerShield)
        {
            StartCoroutine(ShieldRegen());
        }

        if(currentShield == 0 || currentShield <= 0)
        {
            shieldDepleted = true;
        }

        if (health > 3)
        {
            health = 3;
        }

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && shootCooldown < Time.deltaTime)
        {
            Instantiate(bullet, emitter.position, Quaternion.identity);
            shootCooldown = bShootCooldown;
        }

        //Debug Testing
        if (Input.GetKeyDown(KeyCode.Z) && !ImmuneToDamage)
        {
            TakeDamage(0.25f);
            Debug.Log(health);
        }

        if (!damaged)
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, IeFrames * Time.deltaTime * 10);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = 0.75f;
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveHorizontal = 1.0f;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveHorizontal = 0.5f;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        myRB.velocity = movement * speed;

        if (transform.position.y >= 19) {
            transform.position = new Vector3(transform.position.x, 19, transform.position.z);
        }
        if (transform.position.y <= -9)
        {
            transform.position = new Vector3(transform.position.x, -9, transform.position.z);
        }

    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemyBullet" && !ImmuneToDamage)
        {

            TakeDamage(0.2f);
            //Destroy(collision.gameObject);
            //Destroy(gameObject);

            GetComponent<MeshCollider>().enabled = false;
            Invoke("hit", 0.1f);
        }
    }

    public int GetDirection()
    {
        return direction;
    }

    public void TakeDamage(float amount)
    {
        StartCoroutine(InvisibilityFrames());
        if (currentShield >= 0 && !shieldDepleted)
        {
            currentShield -= amount;
            shieldBar.fillAmount = currentShield;
        }

        if (currentShield == 0)
        {
            currentHealth -= amount;
            healthBar.fillAmount = currentHealth;
            DamageFlash();
        }
        if (currentHealth <= 0)
        {
            UIScript.GameOver();
        }
    }

    public void DamageFlash()
    {
        if (damaged)
        {
            damageImage.color = screenFlash;
        }
        if (damaged && health == 0)
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
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("reset", 0.2f);
    }

    public void reset()
    {
        if (i < 2) {
            GetComponent<MeshRenderer>().enabled = true;
            i += 1;
            Invoke("hit", 0.2f);
        } else {
            GetComponent<MeshRenderer>().enabled = true;
            i = 0;
            GetComponent<MeshCollider>().enabled = true;
        }
    }

    public IEnumerator ShieldRegen()
    {
        

        yield return new WaitForSeconds(shieldRegen);
        
    }
}
