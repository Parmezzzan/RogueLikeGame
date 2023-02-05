using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombAttack : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform instancePoint;
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
        if(weaponData.weaponStats[3].level > 0)
            InvokeRepeating("Fire", 0.5f, 1.0f / (weaponData.commonStats.FireRate + weaponData.weaponStats[3].FireRate));
    }
    public void UpdateWeaponData()
    {
        if (weaponData.weaponStats[3].level > 0)
        {
            CancelInvoke();
            InvokeRepeating("Fire", 0.2f, 1.0f / (weaponData.commonStats.FireRate + weaponData.weaponStats[3].FireRate));
        }
    }
    private void Fire()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, weaponData.commonStats.WeaponRange + weaponData.weaponStats[3].WeaponRange);
        if (colliders.Length > 1)
        {
            foreach (var item in colliders)
            {
                if (item.CompareTag(enemyTag))
                {
                    var bullet = objectPool.GetPoolObjectOrNull();
                    bullet.transform.position = instancePoint.position;
                    var bb = bullet.GetComponent<BombBullet>();
                    bb.GetComponent<TrailRenderer>().Clear();
                    bb.SetTargetPoint(item.transform.position);
                    bb.SetDamage((int)weaponData.commonStats.Stright + (int)weaponData.weaponStats[3].Stright);
                    bb.SetSpeed(weaponData.commonStats.BulletSpeed + weaponData.weaponStats[3].BulletSpeed);
                    return;
                }
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, weaponData.commonStats.WeaponRange);
    }
}
