using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExitWood_002 : MonoBehaviour
{
    public GameObject TheTextBox;
    public GameObject PlayerText;
    public GameObject QuestStatus;
    public AudioSource Line003;

    void OnTriggerEnter(Collider col)
    {
        TheTextBox.SetActive(true);
        PlayerText.SetActive(true);
        Line003.Play();
        PlayerText.GetComponent<TextMeshProUGUI>().text = "Looks like a village over that bridge.";
        this.transform.position = new Vector3(0, -1000, 0);
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        PlayerText.GetComponent<TextMeshProUGUI>().text = "";
        TheTextBox.SetActive(false);
        yield return new WaitForSeconds(1);
        PlayerText.GetComponent<TextMeshProUGUI>().text = "I have better get across the bridge!";
        TheTextBox.SetActive(true);
        yield return new WaitForSeconds(3);
        PlayerText.GetComponent<TextMeshProUGUI>().text = "";
        TheTextBox.SetActive(false);
        PlayerText.SetActive(false);
        QuestStatus.GetComponent<TextMeshProUGUI>().text = "Active Quest: Reach The Village";
        this.gameObject.SetActive(false);
    }
}
