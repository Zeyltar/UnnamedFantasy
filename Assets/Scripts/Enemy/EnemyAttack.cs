using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{
    protected Transform _target;
    public Transform Target
    {
        get => _target;
        set => _target = value;
    }
    
    // Start is called before the first frame update
    protected override void Start()
    {
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
    
    
}
