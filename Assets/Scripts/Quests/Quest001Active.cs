using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest001Active : MonoBehaviour
{
    public int TextBoxOnCheck = 0;
    public GameObject MessageBox;
    public GameObject TextBox;
    public GameObject QuestItemToClose;
    public GameObject QuestItemToShow;
    public float TheDistance = 999f;
    public int Range = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;

    }
    void OnMouseOver()
    {
        if (TheDistance < Range && TextBoxOnCheck == 0 && Input.GetButtonDown("Interact"))
        {
            TextBoxOnCheck = 1;
            MessageBox.SetActive(true);
            TextBox.GetComponent<TextMeshProUGUI>().text = "You found the loot.";
            StartCoroutine(CarryOn());
        }
    }
    IEnumerator CarryOn()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        MessageBox.SetActive(false);
        QuestItemToClose.SetActive(false);
        QuestItemToShow.SetActive(true);
    }
}