using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : EnemyController
{
    private Vector2 _direction;
    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }
    [SerializeField] protected float minimumDistance;
    [SerializeField] protected float Speed;
    
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _health.OnDamaged += () => Stop();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        _animator.SetInteger("MoveX", (int)_direction.x);

        _spriteRenderer.flipX = _direction.x switch
        {
            < 0 => false,
            > 0 => true,
            _ => _spriteRenderer.flipX
        };
    }


    public override void Fire()
    { 
        if (_fireTimer <= fireRate)
            return;
        
        _fireTimer = 0;
        
        if (minimumDistance >= _focusSystem.Distance)
            _animator.SetTrigger("Attack");
    }

    public void Move()
    {
        if (_focusSystem.Target == null)
            return;
        if (minimumDistance > _focusSystem.Distance)
            return;
        
        _direction.x = (_focusSystem.Target.transform.position - transform.position).normalized.x > 0 ? 1 : -1;
        
        
        Vector2 velocity = _direction * Speed * Time.deltaTime;
        transform.Translate(velocity);
    }
    
    public void Stop()
    {
        _direction = Vector2.zero;
        _fireTimer = 0;
    }
}
