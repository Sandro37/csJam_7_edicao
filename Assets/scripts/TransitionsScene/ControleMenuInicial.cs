using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMenuInicial : MonoBehaviour
{

    public GameObject telaControles;
    public GameObject telaInicial;

    public void ativarControle()
    {
        telaControles.SetActive(true);
        telaInicial.SetActive(false);
    }

    public void desativarControle()
    {
        telaControles.SetActive(false);
        telaInicial.SetActive(true);
    }
}
