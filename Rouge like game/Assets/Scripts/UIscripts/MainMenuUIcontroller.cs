using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIcontroller : MonoBehaviour
{
    [SerializeField] GameObject kittenHome;
    [SerializeField] GameObject characters;
    [SerializeField] GameObject options;
    public void Quit()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowOptions()
    {
        options.active = true;
        characters.active = false;
        kittenHome.active = false;
    }

    public void HideOptions()
    {
        options.active = false;
        characters.active = true;
        kittenHome.active = true;
    }
}
