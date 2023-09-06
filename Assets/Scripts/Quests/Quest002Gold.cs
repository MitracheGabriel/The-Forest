using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest002Gold : MonoBehaviour
{
    public GameObject TheGold;
    public GameObject GoldPicture;
    public GameObject ThisObject;
    public GameObject Quest002Active;
    public GameObject Quest002Finish;

    void OnMouseOver()
    {
        if (PlayerCasting.DistanceFromTarget <=3 && Input.GetButton("Interact"))
        {
            ThisObject.GetComponent<BoxCollider>().enabled = false;
            GoldPicture.SetActive(true);
            TheGold.SetActive(false);
            Quest002Active.SetActive(false);
            Quest002Finish.SetActive(true);
            ThisObject.SetActive(false);
        }
    }
}
