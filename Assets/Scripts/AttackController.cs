using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;

public class AttackController : MonoBehaviour
{
    private Animator _animator;
    private CharacterContoller _cc;
    
    [SerializeField] protected Attack simpleAttackPrefab;
    protected bool CanSimpleAttack;
    [SerializeField] protected float simpleAttackTimer;

    [SerializeField] protected Attack spellPrefab;
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

            var spell = spellPrefab;
            Instantiate(spell, transform.position, Quaternion.identity);
            spell.Direction = _cc.Looking;
            spell.Use();
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

            var attack = simpleAttackPrefab;
            Instantiate(attack, transform.position, Quaternion.Euler(0,0, _cc.Looking.x > 0 ? 0 : 180));
            attack.Use();
        }
            
    }

    private IEnumerator  ResetSimpleAttack(float timer = 0.5f)
    {
        yield return new WaitForSeconds(timer);
        CanSimpleAttack = true;
    }
}
