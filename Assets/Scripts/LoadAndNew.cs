using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class LoadAndNew : MonoBehaviour
{
    public string fileName = "savefile.data";
    public string LoadCode;
    public static string GlobalLoad;
    public GameObject LoadError;


    void Start()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, fileName)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, fileName), FileMode.Open, FileAccess.Read);
            GameData newData = (GameData)formatter.Deserialize(stream);
            stream.Close();
        }
    }
    public void LoadGame()
    {
        if(LoadCode == "savearea001")
        {
            GlobalLoad = LoadCode;
            SceneManager.LoadScene(2);
        }
        else
        {
            LoadError.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        GlobalLoad = "";
        StreamWriter SaveFile = File.CreateText(fileName);
        SaveFile.Close();
        SceneManager.LoadScene(2);
    }
}
