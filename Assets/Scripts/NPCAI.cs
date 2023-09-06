using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    public int xPos;
    public int zPos;
    public GameObject theDestination;
    public int positionNumber;

    void Start()
    {
        xPos = 33;
        zPos = 168;
        theDestination.transform.position = new Vector3(xPos, 0, zPos);
        positionNumber += 1;
        StartCoroutine(NextLocation());
    }


    void Update()
    {
        transform.LookAt(theDestination.transform);
        transform.position = Vector3.MoveTowards(transform.position, theDestination.transform.position, .05f);
    }

    IEnumerator NextLocation()
    {

        if (positionNumber == 1)
        {
            yield return new WaitForSeconds(10f);
            xPos = 33;
            zPos = 168;
            theDestination.transform.position = new Vector3(xPos, 0, zPos);
            positionNumber += 1;
        }

        if (positionNumber == 2)
        {
            yield return new WaitForSeconds(10f);
            xPos = 13;
            zPos = 168;
            theDestination.transform.position = new Vector3(xPos, 0, zPos);
            positionNumber += 1;
        }
        if (positionNumber == 3)
        {
            yield return new WaitForSeconds(12f);
            xPos = 13;
            zPos = 140;
            theDestination.transform.position = new Vector3(xPos, 0, zPos);
            positionNumber += 1;
        }
        if (positionNumber == 4)
        {
            yield return new WaitForSeconds(14f);
            xPos = 33;
            zPos = 140;
            theDestination.transform.position = new Vector3(xPos, 0, zPos);
            positionNumber = 1;
            StartCoroutine(NextLocation());
        }
    }
}
