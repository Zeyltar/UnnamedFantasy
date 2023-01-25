using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSimpleAttack : Attack
{
    private ParticleSystem _ps;
    private List<ParticleCollisionEvent> _collisionEvents;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
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
        if (!other.CompareTag("Enemy")) return;
        
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(1);
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
