using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawAfterFalling : MonoBehaviour
{
    private bool isDead = false;
    private Vector3 respawnPosition;
    [SerializeField] LayerMask Mask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            Die();
            StartCoroutine(Respawn());
        }
    }
    private void Die()
    {
        isDead = true;
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.2f); ;
        transform.position = respawnPosition;
    }

    private void FixedUpdate()
    {
        if (isDead)
            isDead = false;
        GetLastGround();
    }

    private void GetLastGround()
    {
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, Mask); 

        if (Hit.collider != null)
            respawnPosition = transform.position + new Vector3(-3f, 0, 0);
    }
}
