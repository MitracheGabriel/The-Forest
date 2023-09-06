using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryOnOff : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject Inventory;
    public static bool IsOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && PlayerStats.isAlive && !PlayerStats.IsLocked)
        {
            Debug.Log(Cursor.lockState);
            if (IsOpen)
            {
                Inventory.GetComponent<RectTransform>().localPosition = new Vector3(0, 1000, 0);
                IsOpen = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ThePlayer.GetComponent<FirstPersonController>().enabled = true;
            }
            else
            {
                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
                Inventory.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                IsOpen = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
    }
}
