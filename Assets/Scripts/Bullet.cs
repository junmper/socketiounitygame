﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public GameObject playerFrom;

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();

        if(health != null)
        {
            health.TakeDamage(playerFrom, 10);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(playerFrom, 10);
        }

        Destroy(gameObject);
    }


}
