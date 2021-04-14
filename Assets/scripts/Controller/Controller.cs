using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tempoComeçarMusica());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator tempoComeçarMusica()
    {
        yield return new WaitForSeconds(0.5f);
        SomEfeitos.audio.tocarSom(SomEfeitos.audio.musicaDeFundo[0]);
    }
}
