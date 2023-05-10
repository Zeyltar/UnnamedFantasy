using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAttack : Attack
{
    public float speed;
    
    protected Vector2 _direction;
    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }
    [SerializeField] protected float speedModifier;
    
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
}
