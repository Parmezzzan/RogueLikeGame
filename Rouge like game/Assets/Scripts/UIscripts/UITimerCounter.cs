using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UITimerCounter : MonoBehaviour
{
    [SerializeField]
    private int startTimeSec = 0;
    [SerializeField]
    private bool isIncriment = true;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    public UnityEvent OnReachZero;

    private void Start()
    {
        InvokeRepeating("UpdateTimerText", 1.0f, 1.0f);
    }
    void UpdateTimerText()
    {
        startTimeSec = isIncriment ? ++startTimeSec: --startTimeSec;

        if (startTimeSec == 0)
            OnReachZero.Invoke();

        int minutes = startTimeSec / 60;
        int seconds = startTimeSec % 60;

        string text = "";
        if (minutes > 9)
            text += minutes;
        else 
            text += $"0{minutes}";

        text += ":";
        if (seconds > 9)
            text += seconds;
        else
            text += $"0{seconds}";

        timerText.text = text;
    }
}
