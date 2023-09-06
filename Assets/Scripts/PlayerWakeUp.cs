using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;


public class PlayerWakeUp : MonoBehaviour
{
    public AudioSource intruderSound;
    public GameObject subtitleBox;
    public GameObject subtitleText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(WakeUp());
        PlayerStats.isAlive = true;
    }

    IEnumerator WakeUp()
    {
        
        intruderSound.Play();
        GetComponent<Animation>().Play("WakeUp");
        yield return new WaitForSeconds(1.75f);
        subtitleBox.SetActive(true);
        subtitleText.GetComponent<TextMeshProUGUI>().text = "What the hell was that?";
        yield return new WaitForSeconds(1.25f);
        GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(2f);
        subtitleBox.SetActive(false);
        subtitleText.GetComponent<TextMeshProUGUI>().text = "";
        this.enabled = false;
    }
    
}
