﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoControle : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private GameObject dialogObj;
    [SerializeField] private Image perfil;
    [SerializeField] private Text speechText;
    [SerializeField] private Text atorNomeText;

    [Header("Settings")]
    [SerializeField] private float tempoTextAparecer;
    private string[] sentences;
    private Sprite[] p;
    private string[] actorName;

    private int index;
    private int indexAuxSprite = 0;

    public void speech(Sprite[] p ,string[] txt,string[] actorName)
    {
        dialogObj.SetActive(true);
        this.p = p;
        sentences = txt;
        this.actorName = actorName;
        StartCoroutine(TypeSentences());
    }


    IEnumerator TypeSentences()
    {
        PlayerController.velocidade = 0f;
        PlayerController.podeMexer = false;
        if (indexAuxSprite < p.Length)
        {
            perfil.sprite = p[indexAuxSprite];
            indexAuxSprite++;
        }

        foreach (char letras in actorName[index].ToCharArray())
        {
            atorNomeText.text += letras;
            yield return new WaitForSeconds(tempoTextAparecer);
        }

        foreach (char letras in sentences[index].ToCharArray())
        {
            speechText.text += letras;
            yield return new WaitForSeconds(tempoTextAparecer);
        }

        Dialogo.podeInteragir = false;
        PlayerController.velocidade = PlayerController.guardarVelocidade;


    }

    public void next()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                atorNomeText.text = "";
                StartCoroutine(TypeSentences());
            }
            else
            {
                speechText.text = "";
                atorNomeText.text = "";
                index = 0;
                indexAuxSprite = 0;
                dialogObj.SetActive(false);
                PlayerController.podeMexer = true;
            }
        }
    }
}
