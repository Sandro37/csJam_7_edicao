using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamarSom : MonoBehaviour
{
    public int index = 0;

    public void chamarSom()
    {
        SomEfeitos.audio.tocarSom(SomEfeitos.audio.efeitosDeSom[index]);
    }
}
