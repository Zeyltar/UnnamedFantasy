using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Health health = col.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(health.MaxHealthPoints);
        }
    }
}