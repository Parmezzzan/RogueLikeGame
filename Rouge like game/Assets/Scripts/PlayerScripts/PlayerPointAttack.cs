using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointAttack : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private int poolSize = 20;
    [SerializeField]
    private Transform poolRoot;

    private string enemyTag = "Enemy";
    private ObjectPool objectPool;

    private void Start()
    {
        objectPool = new ObjectPool();
        objectPool.Init(bulletPrefab, poolSize, poolRoot);
        InvokeRepeating("Fire", 0.5f, 1.0f/ weaponData.FireRate);
    }
    public void UpdateWeaponData()
    {
        CancelInvoke();
        InvokeRepeating("Fire", 0.2f, 1.0f / weaponData.FireRate);
    }
    private void Fire()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, weaponData.WeaponAria);
        if (colliders.Length > 1)
        {
            Vector3 target = Vector3.zero;
            float minDistanse = float.MaxValue;

            foreach (var item in colliders)
            {
                if (item.CompareTag(enemyTag))
                {
                    float distanse = Vector3.Distance(transform.position, item.transform.position);
                    if (distanse < minDistanse)
                    {
                        minDistanse = distanse;
                        target = item.transform.position;
                    }
                }
            }
            if (minDistanse != float.MaxValue)
            {
                var narrow = Vector3.Normalize(target - transform.position);
                var bullet = objectPool.GetPoolObjectOrNull();
                bullet.transform.position = firePoint.position;
                var pb = bullet.GetComponent<PointBullet>();
                pb.SetTargetPoint(narrow);
                pb.SetDemage((int)weaponData.Might);
                pb.SetLifeTime(3.0f);
                pb.SetSpeed(weaponData.BulletSpeed);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, weaponData.WeaponAria);
    }
}
