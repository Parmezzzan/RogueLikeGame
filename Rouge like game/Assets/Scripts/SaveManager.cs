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
    public string currentSaveName = "Save1.txt";

    private const string saveFolderPath = "Assets/Resources/SaveGame/";
    public void SaveGameSession()
    {
        string jsonLoad = null;
        using (StreamReader sr = new StreamReader(saveFolderPath + currentSaveName))
        {
            jsonLoad = sr.ReadToEnd();
            print(jsonLoad);
        }

        SaveFile loadFileJson = null;
        if (jsonLoad != null)
            loadFileJson = JsonUtility.FromJson<SaveFile>(jsonLoad);

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
        using (StreamWriter sw = new StreamWriter(saveFolderPath + currentSaveName))
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
    //kittenUpgrade
    public int KittenHomeLevel;
    public int KittenCupLevel;
    public int KittenRugLevel;
}
