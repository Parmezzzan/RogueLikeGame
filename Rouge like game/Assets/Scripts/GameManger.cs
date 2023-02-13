using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField]
    UnityEvent gameOver;
    [SerializeField]
    GameObject pauseMenu;

    private bool gameEnded = false;

    void FixedUpdate()
    {
        if (PlayerData.currentHealth <= 0 && !gameEnded)
            EndGame();
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.active)
        {
            PauseTime();
            pauseMenu.SetActive(true);
        }
    }
    private void EndGame()
	{
        gameEnded = true;
        gameOver?.Invoke();
        Invoke("StopTime", 3.5f);
    }
    public void WonGame()
    {
        gameEnded = true;
        Invoke("StopTime", 3.5f);
    }
    public void RestartLevel()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
    }
    public void ResumeTime()
    {
        Time.timeScale = 1.0f;
    }
    public void PauseTime()
    {
        Time.timeScale = 0.0f;
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
