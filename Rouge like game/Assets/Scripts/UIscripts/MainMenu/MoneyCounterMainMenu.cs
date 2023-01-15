using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounterMainMenu : MonoBehaviour
{
    [SerializeField]
    private Text textCounter;

    public int money;

    private void Start()
    {
        SetMoney(SaveManager.LoadSavefile().money);
    }

    public void SetMoney(int newMoney)
    {
        if(newMoney >= 0)
        {
            money = newMoney;
            textCounter.text = money.ToString();
        }
    }
    public void increaseMoney(int m)
    {
        if (money >= m)
            money -= m;
        SetMoney(money);
    }
}
