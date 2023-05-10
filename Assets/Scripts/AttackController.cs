using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class AttackController : MonoBehaviour
{
    private Animator _animator;
    private CharacterContoller _cc;
    
    [SerializeField] protected WitchAttack simpleAttackPrefab;
    protected bool CanSimpleAttack;
    [SerializeField] protected float simpleAttackTimer;

    [SerializeField] protected WitchAttack spellPrefab;
    protected bool CanCastSpell;
    [SerializeField] protected float spellCastTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterContoller>();
        _animator = GetComponent<Animator>();
        CanSimpleAttack = true;
        CanCastSpell = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CastSpell(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!CanCastSpell)
                return;
            
            CanCastSpell = false;
            StartCoroutine(ResetCastTime(spellCastTimer));
            _animator.SetTrigger("Attack2");

            
            WitchAttack spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);
            spell.Direction = _cc.Looking;
        }
    }
    
    private IEnumerator  ResetCastTime(float timer = 0.5f)
    {
        yield return new WaitForSeconds(timer);
        CanCastSpell = true;
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!CanSimpleAttack)
                return;
            
            CanSimpleAttack = false;
            StartCoroutine(ResetSimpleAttack(simpleAttackTimer));
            _animator.SetTrigger("Attack");

            WitchAttack attack = Instantiate(simpleAttackPrefab, transform.position, Quaternion.identity) ;
            attack.Direction = _cc.Looking;
            if (_cc.Velocity != Vector2.zero)
                attack.speed = _cc.Speed;
            
        }
            
    }

    private IEnumerator  ResetSimpleAttack(float timer = 0.5f)
    {
        yield return new WaitForSeconds(timer);
        CanSimpleAttack = true;
    }
}
