using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class NoticeIntruder : MonoBehaviour
{
    public GameObject intruder;
    public GameObject subtitleBox;
    public GameObject subtitleText;

    void OnTriggerEnter()
    {
        StartCoroutine(IntruderLine());
        GetComponent<BoxCollider>().enabled = false;
    }
    IEnumerator IntruderLine()
    {
        subtitleBox.SetActive(true);
        subtitleText.GetComponent<TextMeshProUGUI>().text = "Hey! What are you doing here?";
        intruder.GetComponent<IntruderRun>().ActivateDestination();
        yield return new WaitForSeconds(3f);
        subtitleBox.SetActive(false);
        subtitleText.GetComponent<TextMeshProUGUI>().text = "";
    }
}
