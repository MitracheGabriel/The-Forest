using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QTESystem : MonoBehaviour
{
    public GameObject displayBox;
    public int QTEGen;
    public bool waitingForKey = true;
    public bool countingDown = false;
    public int correctKey;
    public GameObject passBox;

    void Update()
    {
        if(waitingForKey)
        {
            waitingForKey = false;
            QTEGen = Random.Range(1, 3);
            //coroutine
             if(QTEGen== 1)
            {
                displayBox.GetComponent<TextMeshProUGUI>().text = "[R]";
                countingDown = true;
                StartCoroutine(CountDown());
            }
            if (QTEGen == 2)
            {
                displayBox.GetComponent<TextMeshProUGUI>().text = "[T]";
                countingDown = true;
                StartCoroutine(CountDown());
            }
        }
        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("RKey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("TKey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }
    IEnumerator KeyPressing()
    {
        QTEGen = 4;
        if (correctKey == 1)
        {
            countingDown = false;
            passBox.GetComponent<TextMeshProUGUI>().text = "Correct";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<TextMeshProUGUI>().text = "";
            displayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            FirstQTE.timesDone += 1;
            waitingForKey = true;
        }
        if (correctKey == 2)
        {
            countingDown = false;
            passBox.GetComponent<TextMeshProUGUI>().text = "Incorrect";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<TextMeshProUGUI>().text = "";
            displayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = true;
        }
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3f);
        if (countingDown)
        {
            QTEGen = 5;         
            passBox.GetComponent<TextMeshProUGUI>().text = "Failed";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<TextMeshProUGUI>().text = "";
            displayBox.GetComponent<TextMeshProUGUI>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = true;
        }
    }
}
