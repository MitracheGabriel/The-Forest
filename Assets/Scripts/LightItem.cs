using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightItem : ActionItem
{
    public Light itemLight;
    public bool isOn;

    public override void DoAction()
    {
        if (!Player.isBusy)
        {
            itemLight.enabled = (isOn = !isOn); 
        }
    }

}
