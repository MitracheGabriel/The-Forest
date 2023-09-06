using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject TheNPC;

    void OnTriggerEnter()
    {
        TheNPC.GetComponent<Animation>().Play("Gathering");
    }
    void OnTriggerExit()
    {
        TheNPC.GetComponent<Animation>().Play("Idle");
    }
}
