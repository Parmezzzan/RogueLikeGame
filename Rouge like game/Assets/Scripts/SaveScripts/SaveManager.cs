using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveManager
{
    private static string fileName = "/GameProgress.save";
    public static void SaveSession(SaveFile sessionData)
    {
        SaveFile loadedSave = LoadSavefile();
        loadedSave.money += sessionData.money;
        Save(loadedSave);
    }

    public static SaveFile LoadSavefile()
    {
        string path = Application.persistentDataPath + fileName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            var data = formatter.Deserialize(stream) as SaveFile;
            stream.Close();
            return data;
        }
        else
        {
            Save(new SaveFile() { money = 100 });
            return new SaveFile() { money = 100 };
        }
    }

    public static void Save(SaveFile save)
    {
        BinaryFormatter formater = new BinaryFormatter();
        string path = Application.persistentDataPath + fileName;

        using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
        { 
            formater.Serialize(stream, save);
        }
    }
}

[Serializable]
public class SaveFile
{
    public int money;

    //common powwer stats level
    public int MaxHealth;
    public int HealtRegen;
    public int Armor;
    public int MoveSpeed;
    public int MagnetRange;
    public int Straight;
    public int WeaponRange;
    public int FireRate;
    public int BulletSpeed;

    //kitten house Upgrade
    public int KittenHomeLevel;
    public int KittenCupLevel;
    public int KittenRugLevel;

    //kitten persons upgrade
    public bool mageIsAvailable;
    public bool archerIsAvailable;
    public bool tankIsAvailable;
}