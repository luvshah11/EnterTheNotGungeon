using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
	public particle_timer particlefx;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
//     void OnTriggerEnter(Collider other)
//    {
//        Destroy(gameObject);
//    }
	void OnCollisionEnter(Collision other)
	{
		particle_timer newPartic = Instantiate (particlefx, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
