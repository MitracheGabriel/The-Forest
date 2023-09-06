using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOne : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject ThePlayer;
    public GameObject Canvas;

    void OnTriggerEnter()
    {
        StartCoroutine(PlayCutscenes());
    }
    IEnumerator PlayCutscenes()
    {
        Canvas.SetActive(false);
        Camera1.SetActive(true);
        ThePlayer.SetActive(false);
        yield return new WaitForSeconds(4.5f);       
        Camera2.SetActive(true);
        Camera1.SetActive(false);
        yield return new WaitForSeconds(4.5f);
        Camera2.SetActive(false);
        ThePlayer.SetActive(true);
        Canvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
