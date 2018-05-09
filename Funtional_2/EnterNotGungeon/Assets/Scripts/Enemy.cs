using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{

    //the player's transform
    public Transform target;
    public float chaseRange; //the radius to aggro
    public float speed;
    public En_Gun e_gun;
    public Image healthBar;
    public float health;
public  bool isChasing = false;
    // Use this for initialization
    void Start()
    {
        health = 5.0f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthBar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get distance to player, check if should aggro
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
       

        if (distanceToTarget < chaseRange || isChasing)
            isChasing = true;

        if (isChasing)
        {
            //rotate
            Vector3 targetDir = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetDir, new Vector3(0, 1, 0));

            //move towrads
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            //fire gun 
            e_gun.isFiring = true;
            Debug.Log("isFiring = " + e_gun.isFiring);
        }


        if (transform.position.y < -3.0f)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Death floor");
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Killed");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "p_bullet")
        {
            healthBar.enabled = true;
            health--;
            healthBar.fillAmount = health / 5.0f;
            Debug.Log("Enemy hit! Health: " + health);
        }
    }
}
