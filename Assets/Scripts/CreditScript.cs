using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{

    public GameObject ExecProd;
    public GameObject Credits;

    void Start()
    {
        StartCoroutine(RollCredits());
    }

    IEnumerator RollCredits()
    {
        yield return new WaitForSeconds(.5f);
        ExecProd.SetActive(true);
        yield return new WaitForSeconds(3f);
        ExecProd.SetActive(false);
        Credits.SetActive(true);
        yield return new WaitForSeconds(17f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(1);
    }
}
