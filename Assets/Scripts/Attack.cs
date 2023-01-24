using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    protected bool CanAttack;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        CanAttack = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
}
