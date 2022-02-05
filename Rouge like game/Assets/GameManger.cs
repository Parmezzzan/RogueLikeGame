using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    
    private bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerData.currentHealth <= 0)
		{
            EndGame();
		}
    }
    private void EndGame()
	{
        gameEnded = true;
        Debug.Log("YOU LOST!");
	}
}
