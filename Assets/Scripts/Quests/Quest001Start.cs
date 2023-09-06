using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;
public class Quest001Start : MonoBehaviour
{
    public int TextBoxOnCheck = 0;
    public GameObject MessageBox;
    public GameObject TextBox;
    public string TextMessage;
    public GameObject QuestBox;
    public GameObject QuestText;
    public string QuestName;
    public GameObject QuestItemToShow;
    public int Range = 3;
    public GameObject ThePlayer;
    public float TheDistance = 999f;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;


    }
    void OnMouseOver()
    {
        if (TheDistance < Range)
        {
            if (TextBoxOnCheck == 1)
            {
                if (Input.GetButtonDown("Submit"))
                {
                    MessageBox.SetActive(false);
                    TextBoxOnCheck = 0;
                    TextMessage = "Villager: Get going then!";
                    QuestName = "Active Quest : 'Recover the loot'";
                    QuestText.GetComponent<TextMeshProUGUI>().text = QuestName;
                    QuestItemToShow.SetActive(true);
                    ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                }

                if (Input.GetButtonDown("Cancel"))
                {
                    MessageBox.SetActive(false);
                    TextBoxOnCheck = 0;
                    TextMessage = "Villager: Hello, some bandits have stolen my money. Could you retrieve it from them on the other side of the wall?";
                    QuestName = "Active Quest : (none)";
                    QuestText.GetComponent<TextMeshProUGUI>().text = QuestName;
                    QuestItemToShow.SetActive(false);
                    ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                }

            }
            if (TextBoxOnCheck == 0 && Input.GetButtonDown("Interact"))
            {
                TextBoxOnCheck = 1;
                MessageBox.SetActive(true);
                TextBox.GetComponent<TextMeshProUGUI>().text = TextMessage;
                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            }
        }
    }
}
