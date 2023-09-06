using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestBegin_001 : MonoBehaviour
{
    public GameObject QuestUpdate;
    public TextMeshProUGUI PlayerText;
    public GameObject TextDisplay;
    public AudioSource Line001;
    public AudioSource Line002;
    public int TimerCounter = 0;


    // Use this for initialization
    void Start()
    {
        QuestBegin001();
    }
    void QuestBegin001()
    {
        this.transform.position = new Vector3(0, -1000, 0);
        QuestUpdate.GetComponent<TextMeshProUGUI>().text = "Active Quest: Exit The Woods";
        switch (TimerCounter)
        {
            case 0:
                StartCoroutine(Timer(2f));
                break;
            case 1:
                TextDisplay.SetActive(true);
                Line001.Play();
                PlayerText.text = ("Where am I?");  
                StartCoroutine(Timer(2f));
                break;
            case 2:
                Line002.Play();
                PlayerText.text = ("I need to find a way out of the wood.");         
                StartCoroutine(Timer(2f));
                break;
            case 3:
                PlayerText.text = ("");
                TextDisplay.SetActive(false);
                StartCoroutine(Timer(1f));
                this.gameObject.SetActive(false);
                break;
            default:
                break;
        }

    }
    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        TimerCounter += 1;
        QuestBegin001();


    }

    // Update is called once per frame
    void Update()
    {

    }
}