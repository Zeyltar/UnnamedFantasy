using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTpScript : MonoBehaviour
{
    public Transform destination;
    public Animator transition;

    IEnumerator Fade(Collider2D collision)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        collision.transform.position = destination.position + new Vector3(3, -3, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet entrant est le joueur
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Fade(collision));
            // Téléporte le joueur à la destination

            Debug.Log(destination.position);
        }
    }

}
