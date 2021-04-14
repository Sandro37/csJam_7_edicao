using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminarJogo : MonoBehaviour
{
    public static TerminarJogo terminarJogo;
    public GameObject prefabFim;

    private void Start()
    {
        terminarJogo = this;
    }
    public void ativarFim()
    {
        prefabFim.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prefabFim.gameObject.SetActive(true);
        }
    }

    public void desligarCena()
    {
       
        Application.Quit();
        Debug.Log("Entrei aqui");
    }
}
