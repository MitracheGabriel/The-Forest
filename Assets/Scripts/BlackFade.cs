using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFade: MonoBehaviour
{

    public GameObject BlackScreen;
    public GameObject FadeScreen;


    void Start()
    {
        StartCoroutine(BlackScreenDown(1));
        StartCoroutine(FadeScreenDown(1.99F));
    }
    IEnumerator BlackScreenDown(float time)
    {
        yield return new WaitForSeconds(time);
        FadeScreen.GetComponent<Animator>().enabled = true;
        BlackScreen.SetActive(false);

    }
    IEnumerator FadeScreenDown(float time)
    {
        yield return new WaitForSeconds(time);
        FadeScreen.GetComponent<Animator>().enabled = false;
        FadeScreen.SetActive(false);
    }
}