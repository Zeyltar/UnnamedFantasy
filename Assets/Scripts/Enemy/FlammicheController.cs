using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlammicheController : EnemyController
{
    [SerializeField] protected EnemyAttack AttackPrefab;
    
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

    public override void Fire()
    {
        if (_fireTimer <= fireRate)
            return;
        
        _fireTimer = 0;
        
        EnemyAttack attack = Instantiate(AttackPrefab, transform.position, Quaternion.identity);
        attack.Target = _focusSystem.Target;
    }
}
