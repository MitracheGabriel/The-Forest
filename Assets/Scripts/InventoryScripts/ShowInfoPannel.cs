using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoPannel : MonoBehaviour
{
    public GameObject InfoPanel;

    public void OpenPannel()
    {
        InfoPanel.SetActive(true);
    }
}
