using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_Gun : MonoBehaviour {

	public bool isFiring;
	public Transform firePoint;
	public Bullet bullet;
	public float bulletspeed;
	public float timeBetweenShots;
	private float shotCounter;
	// Use this for initialization
	void Start () {
        isFiring = false;
	}

	// Update is called once per frame
	void Update () {

		if (isFiring) {
            Debug.Log("Enemy is firing");
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0) {
				shotCounter = timeBetweenShots;
				Bullet newbullet = Instantiate (bullet, firePoint.position, firePoint.rotation);
				newbullet.speed = bulletspeed;
                isFiring = false;

                
            }
		} 
        else
        {
            shotCounter = 0;
        }
        
	} 
}