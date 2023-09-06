using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQTE : MonoBehaviour
{
    public GameObject qteObject;
    public static int timesDone;

    void OnTriggerEnter()
    {
        qteObject.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        if(timesDone== 3)
        {
            qteObject.SetActive(false);
        }
    }
}
