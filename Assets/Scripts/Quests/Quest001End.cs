using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;
public class Quest001End : MonoBehaviour
{
    public int TextBoxOnCheck = 0;
    public GameObject MessageBox;
    public GameObject TextBox;
    public string TextMessage;
    public GameObject QuestBox;
    public GameObject QuestText;
    public string QuestName;

    public int Range = 3;
    public GameObject ThePlayer;
    public float TheDistance = 999f;

    public GameObject NPC002Idle;
    public GameObject Quest002;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;

    }
    void OnMouseOver()
    {
       
        if (TheDistance < Range)
        {
            if (TextBoxOnCheck == 0 && Input.GetButtonDown("Interact"))
            {
                TextBoxOnCheck = 1;
                MessageBox.SetActive(true);
                TextBox.GetComponent<TextMeshProUGUI>().text = "Villager: Thank you. Speak to the serveant around the back for more.";
                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
                QuestName = "Active Quest : Speak to the Servant";
                QuestText.GetComponent<TextMeshProUGUI>().text = QuestName;
                NPC002Idle.SetActive(false);
                Quest002.SetActive(true);
            }
            if (TextBoxOnCheck == 1 && (Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel") ))
            {
                ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                MessageBox.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
