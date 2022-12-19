using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData;
    [SerializeField]
    private Transform poolRoot;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int poolSize = 20;
    [SerializeField]
    public Transform firePont;

    private Transform target;
    private ObjectPool bulletPool;
    private string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new ObjectPool();
        bulletPool.Init(bulletPrefab, poolSize, poolRoot);
        InvokeRepeating("UpdateTarget", 0f, 1f / weaponData.FireRate); //вызывает метод сразу после старта и повторяет каждые пол секунды
    }
    public void UpdateWeaponData()
    {
        CancelInvoke();
        InvokeRepeating("UpdateTarget", 0f, 1f / weaponData.FireRate);
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

            if (nearestEnemy != null && shortestDistance <= weaponData.WeaponAria)
                target = nearestEnemy.transform;
            else
                target = null;
        } 
        if(target != null)
            Shoot(target);
    }
    void Shoot (Transform target)
	{
        var bulletGO = bulletPool.GetPoolObjectOrNull();
        if (bulletGO != null)
        {
            bulletGO.transform.position = firePont.position;
            var bullet = bulletGO.GetComponent<Bullet>();
            bullet.Seek(target);
            bullet.UpdateLifeTime(3.0f);
            bullet.speed = weaponData.BulletSpeed;
        }
	}

	void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, weaponData.WeaponAria);
	}
}
