using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private int Money;
    [SerializeField]
    private int startMoney = 10;
    [SerializeField]
    private int expiriense = 0;
    [SerializeField]
    public int maxHealth = 100;
    [SerializeField]
    public HealthBar healthBar;
    [SerializeField]
    public Pathfinding.AstarData pathFinder;
    [SerializeField]
    private Slider expSlider;
    [SerializeField]
    private TextMeshProUGUI expText;
    [SerializeField]
    public UnityEvent OnLVLup;

    public static int currentHealth = 0;
    private int currentLevel = 1;


    private void FixedUpdate()
    {
        /*
        // This holds all graph data
        pathFinder = AstarPath.active.astarData;
        // This creates a Grid Graph
        GridGraph gg = pathFinder.AddGraph(typeof(GridGraph)) as GridGraph;
        // Setup a grid graph with some values
        gg.center = transform.position;
        // Updates internal size from the above values
        gg.UpdateSizeFromWidthDepth();
        // Scans all graphs, do not call gg.Scan(), that is an internal method
        AstarPath.active.Scan();
        */
    }
    void Start()
    {
        Money = startMoney;
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
        expText.text = "Level " + currentLevel; 
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
        if(expiriense >= 100)
        {
            expiriense -= 100;
            LevelUP();
        }
        expSlider.value = expiriense / 100.0f;
    }
    private void LevelUP()
    {
        OnLVLup.Invoke();
        currentLevel++;
        expText.text = "Level " + currentLevel;
    }
}
