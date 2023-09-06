using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public string button;

    void Update()
    {
        if (!Player.isBusy && Input.GetButtonDown(button) && !InventoryOnOff.IsOpen && !PauseGame.IsPaused)
        {
            Debug.Log(button);
            var item = GetComponentInChildren<ActionItem>();
            if (item != null)
            {
                item.DoAction();
            }
        }
    }
}
