using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBR_Tracker : MonoBehaviour
{

    public Transform target;

    private void Start()
    {

    }

    private void Update()
    {
        if (target)
        {
            Vector3 healthPos = target.position;
            healthPos.z += 0.5f;
            transform.position = healthPos;
        }
        else
        {
            Destroy(this);
        }

    }
}
