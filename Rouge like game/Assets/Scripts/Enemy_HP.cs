using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    [SerializeField]
    private PoolManager poolManager;
    [SerializeField]
    private EnemyData enemyData;

    public int health = 100;

    private ObjectPool expPool;
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

        expPool.GetPoolObjectOrNull().transform.position = transform.position;

        if(Random.Range(0,100) < enemyData.moneyChance)
        {
            var pl = GameObject.FindGameObjectWithTag("Player");
            pl.GetComponent<PlayerData>().AddMoney(Random.Range(1, enemyData.maxMoneyFarm));
        }
        Destroy(deathEffectIns, 2f);
    }
    public void SetExpPool(ObjectPool t)
    {
        expPool = t;
    }
}
