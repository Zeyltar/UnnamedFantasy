using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAttack : Attack
{
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
    
    public override void Use()
    {
        base.Use();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
