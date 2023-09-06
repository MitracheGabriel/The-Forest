using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class Area001_Loader : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject StartScript;
    public GameObject VillageBox;
    public static float PlayerX = -9f;
    public static float PlayerY = 6f;
    public static float PlayerZ = 15f;
    public static string LoadedCode;
    public GameObject QuestStatus;

    void Start()
    {
        LoadedCode = LoadAndNew.GlobalLoad;
        if (LoadedCode == "savearea001")
        {
            ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            ThePlayer.transform.position = new Vector3(PlayerX, PlayerY, PlayerZ);
            StartScript.SetActive(false);
            VillageBox.SetActive(false);
            QuestStatus.GetComponent<TextMeshProUGUI>().text = "Active Quest: Reach The Village";
            StartCoroutine(ReEnableControls());

        }
    }
    IEnumerator ReEnableControls()
    {
        yield return new WaitForSeconds(1f);
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
