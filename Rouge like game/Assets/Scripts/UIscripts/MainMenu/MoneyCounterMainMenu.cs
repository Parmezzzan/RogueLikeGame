using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounterMainMenu : MonoBehaviour
{
    [SerializeField]
    private Text textCounter;
    [SerializeField]
    private string path = "Assets/Resources/SaveGame/Save1.txt";
    private void Start()
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

        textCounter.text = loadFileJson.money.ToString();
    }
}
