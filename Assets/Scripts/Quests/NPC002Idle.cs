using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;
public class NPC002Idle : MonoBehaviour
{
    public int TextBoxOnCheck = 0;
    public GameObject MessageBox;
    public GameObject TextBox;
    public string TextMessage;

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
            if (TextBoxOnCheck == 0 && Input.GetButtonDown("Interact"))
            {
                TextBoxOnCheck = 1;
                MessageBox.SetActive(true);
                TextBox.GetComponent<TextMeshProUGUI>().text = TextMessage;
                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            }
            if (TextBoxOnCheck == 1 && (Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel") ))
            {
                TextBoxOnCheck = 0;
                ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                MessageBox.SetActive(false);
            }
        }
    }
}
