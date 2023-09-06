using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRandom : MonoBehaviour
{
    public int objectIndex;
    public int wallIndex;

    public GameObject[] objects = new GameObject[3];
    public GameObject[] wallsPair1 = new GameObject[2];
    public GameObject[] wallsPair2 = new GameObject[2];

    void Start()
    {
        
        objectIndex = Random.Range(0, 3);
        wallIndex = Random.Range(0, 2);
        objects[objectIndex].SetActive(true);
        if(wallIndex == 1)
        {
            foreach(GameObject wall in wallsPair1)
            {
                wall.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject wall in wallsPair2)
            {
                wall.SetActive(true);
            }
        }

    }

}
