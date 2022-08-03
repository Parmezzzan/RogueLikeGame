using TMPro;
using UnityEngine;

public class UITimerCounter : MonoBehaviour
{
    [SerializeField]
    private int startTimeSec = 0;
    [SerializeField]
    private bool isIncriment = true;
    [SerializeField]
    private TextMeshProUGUI timerText;

    private void Start()
    {
        InvokeRepeating("UpdateTimerText", 1.0f, 1.0f);
    }
    void UpdateTimerText()
    {
        startTimeSec++;
        int minutes = startTimeSec / 60;
        int seconds = startTimeSec % 60;
        timerText.text = $"{minutes}:{seconds}";
    }
}
