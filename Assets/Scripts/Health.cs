using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public event Action OnDamaged;
    public event Action OnDeath;
    
    [SerializeField] protected int maxHealthPoints;
    public int MaxHealthPoints { get => maxHealthPoints;}
    protected int _healthPoints;
    public int HealthPoints { get => _healthPoints;}
    
    private bool _canTakeDamage;
    private float _invulnerabilityTimer = 0.5f;
    private bool _isDead;
    private Animator _animator;


    private void Awake()
    {
        _healthPoints = maxHealthPoints;
        _canTakeDamage = true;
        _isDead = false;
        _animator = GetComponent<Animator>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead && !_animator.GetBool("Dead"))
            OnDeath?.Invoke();
    }
    

    public void TakeDamage(int damage)
    {
        if (!_canTakeDamage) return;
        
        _canTakeDamage = false;
        _healthPoints = Mathf.Clamp(_healthPoints - damage, 0, _healthPoints);
        OnDamaged?.Invoke();
        if (_healthPoints != 0)
        {
            if (_animator != null)
                _animator.SetBool("Damaged", true);
            StartCoroutine(ResetInvulnerability(_invulnerabilityTimer));
        }
        else
        {
            Die();
        }
    }

    private IEnumerator ResetInvulnerability(float invulnerabilityTimer)
    {
        yield return new WaitForSeconds(invulnerabilityTimer);
        _canTakeDamage = true;
    }

    private void Die()
    {
        _isDead = true;
        if (_animator != null)
            _animator.SetBool("Dead", _isDead);
        
    }
    
    
}
