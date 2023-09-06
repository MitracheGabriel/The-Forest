using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSwitchOff : MonoBehaviour
{
    void OnTriggerEnter()
    {
        SnowMonitor.OnSnow = 0;
    }
}
