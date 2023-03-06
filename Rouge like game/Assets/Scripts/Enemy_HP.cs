using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    [SerializeField]
    private PoolManager poolDamageText;
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField] bool isPolledMonster = false;

    public int health = 100;

    private ObjectPool expPool;
    public GameObject deathEffect;

    private void Start()
    {
        poolDamageText = GameObject.FindGameObjectWithTag("DamagePoolManager").GetComponent<PoolManager>();
    }
    public void TakeDamage (int damage)
	{
        health -= damage;
        
        var icon = poolDamageText.GetObjectFromPool();
        icon.GetComponent<damageIcon>().setText(damage.ToString());
        icon.gameObject.transform.position = transform.position;

        if (health <= 0)    Die();
    }

    public void Die()
    {
        if (!isPolledMonster)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);

        var deathEffectIns = Instantiate(deathEffect, transform.position, Quaternion.identity);

        expPool.GetPoolObjectOrNull().transform.position = transform.position;

        if(Random.Range(0,100) < enemyData.moneyChance)
        {
            var pl = GameObject.FindGameObjectWithTag("Player");
            pl.GetComponent<PlayerData>().AddMoney(Random.Range(1, enemyData.maxMoneyFarm));
        }
        Destroy(deathEffectIns, 1f);
    }

    public void SetExpPool(ObjectPool t)
    {
        expPool = t;
    }
}
