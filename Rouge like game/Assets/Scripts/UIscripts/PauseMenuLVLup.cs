using UnityEngine;

public class PauseMenuLVLup : MonoBehaviour
{
    int? skill = null;
    //fake commit
    public void onLVLup()
    {
        Invoke("Stop", 1.6f);
    }
    private void Stop()
	{
        Invoke("Pause", 0.8f);
    }
    private void Pause()
    {
        Time.timeScale = 0.0f;
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
