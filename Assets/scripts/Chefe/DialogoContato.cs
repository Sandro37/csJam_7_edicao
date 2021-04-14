using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoContato : MonoBehaviour
{
    private DialogoControle dialogoControle;
    private Dialogo dialogo;
    private BoxCollider2D boxCollider2D;


    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        dialogo = GetComponent<Dialogo>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.podeMexer = false;
            PlayerController.velocidade = 0f;
            PlayerController.movementX = 0f;

            dialogoControle = FindObjectOfType<DialogoControle>();
            dialogoControle.speech(dialogo.perfil, dialogo.speechTxt, dialogo.actorName);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCollider2D.enabled = false;
        }
    }
}
