using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    public GameObject endScreen;

    void Awake()
    {
        StartCoroutine(end());
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
    }
}
