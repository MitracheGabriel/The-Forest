using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using TMPro;


public class BFirstTrigger : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject TheMarker;

    void OnTriggerEnter()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
        gameObject.GetComponent<Collider>().enabled = false;

    }
    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<TextMeshProUGUI>().text = "Looks like a weapon on that table";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        TheMarker.SetActive(true);
    }

}
