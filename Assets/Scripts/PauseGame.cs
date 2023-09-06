using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject PauseMenu;
    public static bool IsPaused = false;

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && PlayerStats.isAlive && !PlayerStats.IsLocked)
        {
            if (!IsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Resume()
    {
        Debug.Log("Resumed");
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        PauseMenu.SetActive(false);
    }
    public void Pause()
    {
        IsPaused = true;
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenu.SetActive(true);
    }
}
