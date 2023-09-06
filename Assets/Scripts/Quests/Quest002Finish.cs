using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class Quest002Finish : MonoBehaviour
{
    public int TextBoxOnCheck = 0;
    public GameObject MessageBox;
    public GameObject TextBox;
    public GameObject QuestBox;
    public GameObject QuestText;
    public int Range = 3;
    public GameObject ThePlayer;
    public float TheDistance = 999f;
    public GameObject TheGold;
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
                TextBox.GetComponent<TextMeshProUGUI>().text = "Servant: Thank you very much!";
                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
                QuestText.GetComponent<TextMeshProUGUI>().text = "Active Quest: Explore";
                TheGold.SetActive(false);
                
            }
            if (TextBoxOnCheck == 1 && (Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel")))
            {
                ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                MessageBox.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

}
