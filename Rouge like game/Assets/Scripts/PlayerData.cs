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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
		{
            TakeDamage(20);
		}
    }

    void TakeDamage (int damage)
	{
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
	}
}
