using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class WitchSimpleAttack : Attack
{
    private ParticleSystem _ps;
    private List<ParticleCollisionEvent> _collisionEvents;
    
   
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        transform.localScale = new Vector3((Direction.x > 0) ? 1f : -1f, 1f, 1);
        _ps = GetComponent<ParticleSystem>();
        var main = _ps.main;
        main.stopAction = ParticleSystemStopAction.Callback;
        _collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            int numCollisionEvents = _ps.GetCollisionEvents(other, _collisionEvents);
        
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        
        
            Health health = other.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(damage);
            }
        }
        
        

    }
    
    

    private void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }

    public override void Use()
    { 
        base.Use();
        
        Debug.Log("Attack!");
    }
}
