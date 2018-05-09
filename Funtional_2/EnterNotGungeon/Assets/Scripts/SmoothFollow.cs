using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

	public Transform target;
	public float cameraspeed = 15;
	public float zOffSet = 23;
	public bool smoothfollow = true;
	
	// Update is called once per frame
	void Update () {
		if (target) {
			Vector3 newPos = transform.position;
			newPos.x = target.position.x;
			newPos.z = target.position.z;

			if (!smoothfollow)
				transform.position = newPos;
			else
				transform.position = Vector3.Lerp (transform.position, newPos, cameraspeed * Time.deltaTime);
		}
	}
}
