using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;

public class AttackController : MonoBehaviour
{
    [SerializeField] protected Attack SimpleAttack;
    private Animator _animator;
    private CharacterContoller _cc;
    
    protected bool CanSimpleAttack;
    [SerializeField] protected float SimpleAttackTimer;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterContoller>();
        _animator = GetComponent<Animator>();
        CanSimpleAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!CanSimpleAttack)
                return;
            
            CanSimpleAttack = false;
            StartCoroutine(ResetSimpleAttack(SimpleAttackTimer));
            _animator.SetTrigger("Attack");

            var attack = SimpleAttack;
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
