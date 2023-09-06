using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StartBossFight : MonoBehaviour
{
    public GameObject player;
    public Camera cameraView;
    public GameObject sacrifices;
    public GameObject boss;

    void Awake()
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponentInChildren<Camera>().enabled = false;
        cameraView.enabled = true;

        sacrifices.SetActive(true);
        boss.SetActive(true);

        StartCoroutine(Fight());
    }
    IEnumerator Fight()
    {
        yield return new WaitForSeconds(3f);
        cameraView.enabled = false;
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponentInChildren<Camera>().enabled = true;
    }
}
