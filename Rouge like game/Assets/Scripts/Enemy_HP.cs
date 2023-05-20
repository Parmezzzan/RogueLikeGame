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
    public PoolManager deathFXpool;

    private void Start()
    {
        poolDamageText = GameObject.FindGameObjectWithTag("DamagePoolManager").GetComponent<PoolManager>();
        deathFXpool = GameObject.FindGameObjectWithTag("DeathPoolManager").GetComponent<PoolManager>();
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
        FXAudioController.PlayDeath();

        if (!isPolledMonster)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);

        
        var o = deathFXpool.GetObjectFromPool();
        o.transform.position = gameObject.transform.position;
        o.GetComponent<AutoDestroy>().Reload();
        o.GetComponent<ParticleSystem>().Play();

        expPool.GetPoolObjectOrNull().transform.position = transform.position;

        if(Random.Range(0,100) < enemyData.moneyChance)
        {
            var pl = GameObject.FindGameObjectWithTag("Player");
            pl.GetComponent<PlayerData>().AddMoney(Random.Range(1, enemyData.maxMoneyFarm));
        }
    }

    public void SetExpPool(ObjectPool t)
    {
        expPool = t;
    }
}
