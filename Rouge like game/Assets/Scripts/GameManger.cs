using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManger : MonoBehaviour
{
    [SerializeField]
    UnityEvent gameOver;

    private bool gameEnded = false;
    void Update()
    {
        if (PlayerData.currentHealth <= 0 && !gameEnded)
            EndGame();
    }
    private void EndGame()
	{
        gameEnded = true;
        gameOver.Invoke();
    }
}
