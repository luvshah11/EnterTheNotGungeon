using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_timer : MonoBehaviour {

	//public ParticleSystem ps;
	// Use this for initialization
	void Awake () {
//		particle.GetComponent<ParticleSystem> ().emission.enabled = true;
		Destroy (gameObject, 2);
		//ps.GetComponent<ParticleSystem>();

	}

	// Update is called once per frame
	void Update () {
		
	}
}
