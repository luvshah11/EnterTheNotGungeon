using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Turret : MonoBehaviour {
    //the player's transform
    public Transform target;
    public float fireRange; //the radius to aggro
    public float speed;
    public En_Gun Re_gun;
    public En_Gun Le_gun;
    public Image healthBar;
    public float health;
    // Use this for initialization
    void Start()
    {
        healthBar.enabled = false;
        health = 3.0f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //get distance to player, check if should aggro
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < fireRange)
        {
            //rotate
            Vector3 targetDir = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetDir, new Vector3(0, 1, 0));
           

            //fire guns 
            Le_gun.isFiring = true;
            Re_gun.isFiring = true;
            
        }


        if (transform.position.y < -3.0f)
        {
            Destroy(gameObject);
            Debug.Log("turret Death floor");
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Turret Killed");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "p_bullet")
        {
            healthBar.enabled = true;
            health--;
            healthBar.fillAmount = health / 3.0f;
            Debug.Log("Turret hit! Health: " + health);
        }
    }
}

