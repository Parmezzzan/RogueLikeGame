using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    [SerializeField]
    private GameObject expSoulSphere;
    [SerializeField]
    private PoolManager poolManager;

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

    void Die ()
	{
        Destroy(gameObject);
        GameObject deathEffectIns = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(expSoulSphere, transform.position, Quaternion.identity);
        Destroy(deathEffectIns, 2f);
    }
}
