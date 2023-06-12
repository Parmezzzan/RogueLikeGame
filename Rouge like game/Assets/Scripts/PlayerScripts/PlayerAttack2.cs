using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    [SerializeField]
    WeaponData weaponData;
    [SerializeField]
    Transform poolRoot;
    [SerializeField]
     GameObject bulletPrefab;
    [SerializeField]
    int poolSize = 20;
    [SerializeField]
    public Transform firePont;
    [SerializeField]
    PoolManager fxPool;
    [SerializeField]
    MusicPlayer musicPlayer;

    Transform target;
    ObjectPool bulletPool;
    string enemyTag = "Enemy";

    void Start()
    {
        bulletPool = new ObjectPool();
        bulletPool.Init(bulletPrefab, poolSize, poolRoot);
        InvokeRepeating("UpdateTarget", 0f, 1f / (weaponData.commonStats.FireRate + weaponData.weaponStats[0].FireRate)); //вызывает метод сразу после старта и повторяет каждые пол секунды
    }
    public void UpdateWeaponData()
    {
        CancelInvoke();
        InvokeRepeating("UpdateTarget", 0f, 1f / (weaponData.commonStats.FireRate + weaponData.weaponStats[0].FireRate));
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

            if (nearestEnemy != null && shortestDistance <= weaponData.commonStats.WeaponRange + weaponData.weaponStats[0].WeaponRange)
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
            bullet.GetComponent<TrailRenderer>().Clear();
            bullet.Seek(target);
            bullet.UpdateLifeTime(3.0f);
            bullet.PoolFX(fxPool);
            bullet.damage = (int)(weaponData.weaponStats[0].Might + weaponData.commonStats.Might);
            bullet.speed = weaponData.commonStats.BulletSpeed +  weaponData.weaponStats[0].BulletSpeed;
            bullet.MusicHitFx(musicPlayer);
        }
	}

	void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, weaponData.commonStats.WeaponRange);
	}
}
