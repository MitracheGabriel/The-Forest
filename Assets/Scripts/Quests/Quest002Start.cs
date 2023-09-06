using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class Quest002Start : MonoBehaviour
{
    public int TextBoxOnCheck = 0;
    public GameObject MessageBox;
    public GameObject TextBox;
    public GameObject QuestBox;
    public GameObject QuestText;

    public GameObject Key001;
    public GameObject CaveDoor;
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
                    ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                    QuestText.GetComponent<TextMeshProUGUI>().text = "Active Quest: Retrieve the Bullion";
                    MessageBox.SetActive(false);
                    TextBoxOnCheck = 0;
                    Key001.SetActive(true);
                    CaveDoor.SetActive(true);
                    ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                }

                if (Input.GetButtonDown("Cancel"))
                {
                    MessageBox.SetActive(false);
                    TextBoxOnCheck = 0;
                    QuestText.GetComponent<TextMeshProUGUI>().text = "Active Quest : (none)";
                    ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                }

            }
            if (TextBoxOnCheck == 0 && Input.GetButtonDown("Interact"))
            {
                TextBoxOnCheck = 1;
                MessageBox.SetActive(true);
                TextBox.GetComponent<TextMeshProUGUI>().text = "Servant: I want you to retrieve some Gold Bulion from the cave down the path. Here is the key.";
                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            }
        }
    }

}
