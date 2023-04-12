using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WitchProjectileAttack : Attack
{
    [SerializeField] protected GameObject explosionPrefab;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player"))
        {
            if (col.CompareTag("Enemy"))
            {
                var health = col.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
            
            //TODO Particles explosions
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        
    }
    
    public override void Use()
    {
        base.Use();
    }
}
