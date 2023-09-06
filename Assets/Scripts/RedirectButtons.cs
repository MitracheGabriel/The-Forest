using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectButtons : MonoBehaviour
{
 
    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    } 

    public void Quit()
    {
        Application.Quit();
    } 

}
