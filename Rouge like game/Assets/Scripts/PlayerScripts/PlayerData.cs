using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Pathfinding;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private int Money = 0;
    [SerializeField]
    private int startMoney = 10;
    [SerializeField]
    private int expiriense = 0;
    [SerializeField]
    public int maxHealth = 100;
    [SerializeField]
    public float moveSpeed = 5.0f;
    [SerializeField]
    public int armor = 1;
    [SerializeField]
    public float magnetRadius = 2.0f;

    [Space(10)]
    [SerializeField]
    public float regenerationCooldownSec = 2.0f;
    [SerializeField]
    public int healthRegenerationPower = 2;

    [Space(10)]
    [SerializeField]
    public HealthBar healthBar;
    [SerializeField]
    private Slider expSlider;
    [SerializeField]
    private UICoinCounter CoinCounter;
    [SerializeField]
    private TextMeshProUGUI expText;
    [SerializeField]
    public UnityEvent OnLVLup;

    [SerializeField]
    public UnityEvent DataHasUpdated;

    public static int currentHealth = 0;
    private int currentLevel = 1;

    void Start()
    {
        Money = startMoney;

        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth * 100 / maxHealth);

        expText.text = "Level " + currentLevel;

        InvokeRepeating("HealthRegeneration", 0.0f, regenerationCooldownSec);
    }
    private void HealthRegeneration()
    {
        Heal(healthRegenerationPower);
    }
    public void TakeDamage (int damage)
	{
        damage -= armor;
        if (damage > 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth * 100 / maxHealth);
        }
	}
    public void Heal(int healPower)
    {
        if (healPower > 0)
            currentHealth += healPower;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth * 100 / maxHealth);
    }
    public void AddEXP(int exp)
    {
        expiriense += exp;
        if(expiriense >= 100)
        {
            expiriense -= 100;
            LevelUP();
        }
        expSlider.value = expiriense / 100.0f;
    }
    public void AddMoney(int addtionMoney)
    {
        Money += addtionMoney;
        CoinCounter.UpdateCounter(Money);
    }
    private void LevelUP()
    {
        OnLVLup.Invoke();
        currentLevel++;
        expText.text = "Level " + currentLevel;
    }
    public int GetAccMonney() { return Money; }
}
