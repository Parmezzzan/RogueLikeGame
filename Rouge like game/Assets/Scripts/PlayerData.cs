using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private int Money;
    [SerializeField]
    private int startMoney = 10;
    [SerializeField]
    private int expiriense = 0;

    public int maxHealth = 100;
    public static int currentHealth;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }
    public void TakeDamage (int damage)
	{
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
	}
    public void Heal(int healPower)
    {
        if (healPower > 0)
            currentHealth += healPower;

        healthBar.SetHealth(currentHealth);
    }
    public void AddEXP(int exp)
    {
        expiriense += exp;
    }
}
