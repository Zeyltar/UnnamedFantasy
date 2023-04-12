using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed;
    
    private Vector2 _direction;
    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }
    [SerializeField] protected float speedModifier;
    [SerializeField] protected int damage;
    // Start is called before the first frame update
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(_direction * (Time.deltaTime * speed * speedModifier));
    }

    public virtual void Use()
    {
    }
}
