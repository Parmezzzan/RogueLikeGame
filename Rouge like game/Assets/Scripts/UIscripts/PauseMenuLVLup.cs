using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuLVLup : MonoBehaviour
{
    int? skill = null;
    public void onLVLup()
    {
        Time.timeScale = 0.3f;
    }
    public void SkkillChoise(int N)
    {
        skill = N;
    }
    public void ExitMenu()
    {
        if(skill != null)
        {
            Time.timeScale = 1.0f;
            skill = null;
            gameObject.SetActive(false);
        }
    }
}
