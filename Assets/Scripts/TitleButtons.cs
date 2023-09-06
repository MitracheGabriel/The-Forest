using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 30), "Play Game"))
        {
            SceneManager.LoadScene(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 40, 100, 30), "Quit Game"))
        {
            Application.Quit();
        }
    }
}
