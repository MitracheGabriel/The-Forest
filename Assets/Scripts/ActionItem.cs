using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionItem: MonoBehaviour
{
    public abstract void DoAction();
    void OnDestroy()
    {
        Player.isBusy = false;
    }
}
