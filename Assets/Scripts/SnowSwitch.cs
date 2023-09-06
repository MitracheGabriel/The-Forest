using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSwitch : MonoBehaviour
{
    void OnTriggerEnter()
    {
        SnowMonitor.OnSnow = 1;
    }
}
