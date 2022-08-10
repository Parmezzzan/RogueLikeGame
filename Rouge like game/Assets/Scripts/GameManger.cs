using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
        Invoke("StopTime", 2.0f);
    }
    public void WonGame()
    {
        gameEnded = true;
        Invoke("StopTime", 2.0f);
    }
    public void RestartLevel()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
    private void StopTime()
    {
        Time.timeScale = 0.0f;
    }
}
