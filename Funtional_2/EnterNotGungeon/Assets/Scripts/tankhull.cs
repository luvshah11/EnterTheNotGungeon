using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class tankhull : MonoBehaviour {
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public Rigidbody rig;
    public Vector3 playerTrans;
    public Gun gun;
    public Image healthBar;
    private float health;
    public bool isHitable = true;
    public bool isDodging = false;
    // Use this for initialization
    void Start () {
        healthBar.enabled = false;
        rig = GetComponent<Rigidbody>();
        playerTrans = transform.position;
        health = 10.0f;
    }
	
	// Update is called once per frame
	void Update () {

        //move and rotate
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        Vector3 movement = -transform.right * translation;
        rig.MovePosition(rig.position + movement);
        transform.Rotate(0, 0, rotation);

        //firing gun
        if (Input.GetMouseButton(0))
        {
            gun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;

        }

        if (health <= 0 || transform.position.y < -3.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (isDodging)
        {
            if (Input.GetKeyDown("space"))
            {
                this.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
                jump();
                isHitable = false;
            }
            if (Input.GetKeyUp("space"))
            {
                this.GetComponent<Renderer>().material.color = new Color(0, 0, 1);
                isHitable = true;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //if
        if (other.gameObject.tag == "En_bullet")
        {
            healthBar.enabled = true;
            health--;
            healthBar.fillAmount = health / 10.0f;
            Debug.Log("Player hit! Health: " + health);
        }



        if (other.gameObject.tag == "powerup")
        {
            Debug.Log("Powered Up");
            //power up code
            gun.bulletspeed = 15.0f;
        }

        if (other.gameObject.tag == "powerup2")
        {
            Debug.Log("Powered Up");
            //power up code
            isDodging = true;
        }
    }

    void jump()
    {
        Vector3 ground_hight = transform.position;
        Vector3 jump_height = ground_hight + new Vector3(0, 5, 0);
        transform.position = Vector3.MoveTowards(transform.position, jump_height, 10.0f * speed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, ground_hight, speed * Time.deltaTime);
    }

}

