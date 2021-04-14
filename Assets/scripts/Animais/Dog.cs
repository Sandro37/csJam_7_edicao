using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dog : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Image keys;
    [SerializeField] private Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && Dialogo.podeInteragir)
        {
            Debug.Log("Doguinho colidindo com o player");
            keys.gameObject.SetActive(true);
            anim.SetTrigger("on");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Doguinho não está mais colidindo com o player");
            anim.SetTrigger("off");
            keys.gameObject.SetActive(false);

            if (!Dialogo.podeInteragir)
            {
                
                PlayerController.playerLimiteTela.xMin = 3.47106f;
                PlayerController.playerLimiteTela.XMax = 49.02f;
                CameraFollow.cameraLimiteTela.xMin = 11.9f;
                CameraFollow.cameraLimiteTela.XMax = 40.93f;
            }
        }
    }
}
