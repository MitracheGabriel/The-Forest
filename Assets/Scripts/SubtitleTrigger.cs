using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class SubtitleTrigger : MonoBehaviour
{
    public GameObject SubtitleBox;
    public GameObject SubtitleText;
    public GameObject[] ObjectsToActivate;
    public GameObject[] ObjectsToDeactivate;
    public float LineTimeout = 3f;
    public bool isLocked;
    public FirstPersonController player;
    public string[] Line = new string[1];

    void OnTriggerEnter()
    {
        if (player && isLocked)
        {
            player.enabled = false;
            PlayerStats.IsLocked = true;
        }
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(SayLine());
    }

    IEnumerator SayLine()
    {
        SubtitleBox.SetActive(true);
        foreach (var obj1 in ObjectsToActivate)
        {
            obj1.SetActive(true);
        }  
        foreach (var obj1 in ObjectsToDeactivate)
        {
            obj1.SetActive(false);
        }
        foreach (var line in Line)
        {
            SubtitleText.GetComponent<TextMeshProUGUI>().text = line;
            yield return new WaitForSeconds(LineTimeout);
        }
        if(player)player.enabled = true;
        PlayerStats.IsLocked = false;

        SubtitleBox.SetActive(false);
        SubtitleText.GetComponent<TextMeshProUGUI>().text = "";
    }
}
