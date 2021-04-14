using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finisher : MonoBehaviour
{

    private Load load;
    private void Awake()
    {
        load = FindObjectOfType<Load>();
    }

    public void chamarLoadScene()
    {
        load.startCoroutine();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player");
        {
            chamarLoadScene();
        }
    }
}
