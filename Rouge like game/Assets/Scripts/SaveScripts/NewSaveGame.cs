using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSaveGame : MonoBehaviour
{
    [SerializeField]
    MainMenuUIcontroller MainMenuU;
    public void NewGame()
    {
        SaveManager.Save(new SaveFile());
        MainMenuU.NewGame();
    }
}
