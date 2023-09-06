using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public GameObject TheLedge;
    public GameObject ThePlayer;

    void OnTriggerEnter()
    {
        ThePlayer.transform.parent = TheLedge.transform; 
    }
    void OnTriggerExit()
    {
        ThePlayer.transform.parent = null;
    }
}
