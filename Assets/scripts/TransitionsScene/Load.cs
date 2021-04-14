using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    [SerializeField] private float timeTransicao;
    [SerializeField] private Animator anim;

    public void startCoroutine()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int level)
    {
        anim.SetTrigger("load");
        yield return new WaitForSeconds(timeTransicao);
        SceneManager.LoadScene(level);
    }
}
