using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    
    [SerializeField] protected int healthPoints;
    public int HealthPoints { get => healthPoints;}
    
    private bool _canTakeDamage;
    private float _invulnerabilityTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        _canTakeDamage = true;
        _invulnerabilityTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void TakeDamage(int damage)
    {
        if (!_canTakeDamage) return;

        _canTakeDamage = false;
        
        StartCoroutine(ResetInvulnerability(_invulnerabilityTimer));
        
        healthPoints = Mathf.Clamp(healthPoints - damage, 0, healthPoints);
        if (healthPoints == 0)
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
        Destroy(gameObject);
    }
}
