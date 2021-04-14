using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
     public Sprite[] perfil;
     public string[] speechTxt;
     public string[] actorName;

    [SerializeField] private LayerMask layer;
    [SerializeField] private float radius;

    private DialogoControle dialogoControle;
    private bool isRadius;
    public static bool podeInteragir = true;

    private void Start()
    {
        dialogoControle = FindObjectOfType<DialogoControle>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && isRadius && podeInteragir && PlayerController.estaParado)
        {
            dialogoControle.speech(perfil, speechTxt, actorName);
        }
    }
    private void FixedUpdate()
    {
        interagindo();
    }

    public void interagindo()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layer);

        if(hit != null)
        {
            isRadius = true;
        }
        else
        {
            isRadius = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
