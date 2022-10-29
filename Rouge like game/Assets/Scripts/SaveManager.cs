using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    public string path = "Assets/Resources/SaveGame/Save1.txt";
    public void SaveGameSession()
    {
        string jsonLoad = null;
        using (StreamReader sr = new StreamReader(path))
        {
            jsonLoad = sr.ReadToEnd();
            print(jsonLoad);
        }

        SaveFile loadFileJson = null;
        if (jsonLoad != null)
        {
            loadFileJson = JsonUtility.FromJson<SaveFile>(jsonLoad);
        }

        if (loadFileJson != null)
        {
            loadFileJson.money += playerData.GetAccMonney();
        }
        else
        {
            loadFileJson = new SaveFile();
            loadFileJson.money = playerData.GetAccMonney();
        }

        var stringSave = JsonUtility.ToJson(loadFileJson);
        using (StreamWriter sw = new StreamWriter(path))
        {
            print(stringSave);
            sw.Write(stringSave);
            //sw.Flush();
            sw.Close();
        }
    }
}
[Serializable]
public class SaveFile
{
    public int money;
}
