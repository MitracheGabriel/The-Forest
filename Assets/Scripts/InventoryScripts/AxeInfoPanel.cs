using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeInfoPanel : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject Axe;
    public GameObject ItemEquipped;

    public void ItemEquip()
    {
        Axe.SetActive(true);
        InfoPanel.SetActive(false);
        ItemEquipped.SetActive(true);
    }
    public void ItemCancel()
    {
        InfoPanel.SetActive(false);
    }
}
