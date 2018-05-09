using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public bool isFiring;
	public Transform firePoint;
	public Bullet bullet;
	public float bulletspeed;
	public float timeBetweenShots;
	private float shotCounter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isFiring) {
			shotCounter -= Time.deltaTime;
			if (shotCounter <= 0) {
				shotCounter = timeBetweenShots;
				Bullet newbullet = Instantiate (bullet, firePoint.position, firePoint.rotation);
				newbullet.speed = bulletspeed;
			}
		} 
		else 
		{
			shotCounter = 0;
		}
	}
}
