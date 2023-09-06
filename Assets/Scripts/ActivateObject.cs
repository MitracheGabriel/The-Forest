using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public float Delay = 3f;
    public GameObject[] ObjectsToActivate;

    void Awake()
    {
        StartCoroutine(ActivateObjects());
    }

    IEnumerator ActivateObjects()
    {
        foreach(var obj in ObjectsToActivate)
        {
            yield return new WaitForSeconds(Delay);
            obj.SetActive(true);
        }
    }

}
