using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    [SerializeField]
    private GameObject expSoulSphere;
    [SerializeField]
    private PoolManager poolManager;
    [SerializeField]
    private EnemyData enemyData;
    [SerializeField]
    private GameObject moneyFarmObject;

    public int health = 100;

    public GameObject deathEffect;

    private void Start()
    {
        poolManager = GameObject.FindGameObjectWithTag("DamagePoolManager").GetComponent<PoolManager>();
    }
    public void TakeDamage (int damage)
	{
        health -= damage;
        
        if (health <= 0)
		{
            Die();
		}
        var icon = poolManager.GetObjectFromPool();
        icon.GetComponent<damageIcon>().setText(damage.ToString());
        icon.gameObject.transform.position = transform.position;
	}

    void Die()
    {
        Destroy(gameObject);
        GameObject deathEffectIns = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(expSoulSphere, transform.position, Quaternion.identity);

        if(Random.Range(0,100) < enemyData.moneyChance)
        { 
            var moneyObj = Instantiate(moneyFarmObject,
                transform.position + new Vector3(Random.Range(0, 1.0f),
                Random.Range(0, 1.0f), 0.0f), Quaternion.identity);
            moneyObj.GetComponent<MoneyFarmController>().SetAmount(Random.Range(1, enemyData.maxMoneyFarm));
        }
        Destroy(deathEffectIns, 2f);
    }
}
