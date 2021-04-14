using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomEfeitos : MonoBehaviour
{
    public AudioClip[] efeitosDeSom;
    public AudioClip[] musicaDeFundo;

    private AudioSource AudioSource;
    public static SomEfeitos audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = this;
        AudioSource = GetComponent<AudioSource>();
    }

    public void tocarSom(AudioClip audio)
    {
        AudioSource.PlayOneShot(audio);
    }
}
