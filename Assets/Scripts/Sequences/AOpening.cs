using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using TMPro;

public class AOpening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;

    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }
    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<TextMeshProUGUI>().text = "I need to get out of here.";
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;

    }
}
