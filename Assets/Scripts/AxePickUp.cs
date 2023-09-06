using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AxePickUp : MonoBehaviour
{
    public float TheDistance;

    public GameObject FakeAxe;
    public GameObject RealAxe;

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            
            if (Input.GetButton("Interact"))
            {
                transform.position = new Vector3(0, 0, -999);
                FakeAxe.SetActive(false);
                RealAxe.SetActive(true);

            }
        }
    }
}
