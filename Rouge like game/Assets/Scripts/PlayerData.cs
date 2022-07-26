using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int Money;
    public int startMoney;


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
}
