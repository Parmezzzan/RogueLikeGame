using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;      //скорость стрельбы (1 сек)
    private float fireCountdown = 0f;

    [Header("Attachements")]
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePont;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //вызывает метод сразу после старта и повторяет каждые пол секунды
    }

    void UpdateTarget ()
	{
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
		{
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
		    if (distanceToEnemy < shortestDistance)
			{
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
			}

            if (nearestEnemy != null && shortestDistance <= range)
			{
                target = nearestEnemy.transform;
			} else
			{
                target = null;
			}

        }            
	}

    // Update is called once per frame
    void Update()
    {
        if (target == null)   //если таргета нет то ничего не делает
            return;

        if (fireCountdown <= 0f)
		{
            Shoot();
            fireCountdown = 1f / fireRate;
		}

        fireCountdown -= Time.deltaTime;
    }

    void Shoot ()
	{
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePont.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
		bullet.Seek(target);
	}

	void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
	}
}
