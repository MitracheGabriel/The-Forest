using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveGame : MonoBehaviour
{
    public string fileName = "savefile.data";
    public GameData data;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "FPSController")
        {
            data.PlayerPosition = col.transform.position;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, fileName), FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, data);
            stream.Close();
        }
    }
    
}
public class GameData
{
    public Vector3 PlayerPosition;

}
