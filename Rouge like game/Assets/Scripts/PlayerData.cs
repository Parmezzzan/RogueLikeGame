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
    public AstarPath pathFinder;
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
        customiseAStar();


    }
    void customiseAStar()
    {
        NavGraph[] graph = pathFinder.graphs;
        foreach (var item in graph)
        {
            item.RelocateNodes(Matrix4x4.TRS(gameObject.transform.position, Quaternion.identity, Vector3.one));
        }

        pathFinder.Scan();
        /*
        foreach (IUpdatableGraph graph in graphs)
        { 
            graph.width = w;

            graph.depth = d;
            graph.center = new Vector3(x, y, 0);

            graph.UpdateSizeFromWidthDepth();

        }
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
