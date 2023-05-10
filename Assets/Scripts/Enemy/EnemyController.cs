using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected float fireRate;
    protected float _fireTimer;
    protected FocusSystem _focusSystem;
    protected Health _health;
    protected Animator _animator;
    protected SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _focusSystem = GetComponent<FocusSystem>();
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _health.OnDeath += () => Destroy(gameObject);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_fireTimer <= fireRate)
            _fireTimer += Time.deltaTime;
    }

    public virtual void Fire()
    {
        if (_fireTimer <= fireRate)
            return;
        
        _fireTimer = 0;
    }
}
