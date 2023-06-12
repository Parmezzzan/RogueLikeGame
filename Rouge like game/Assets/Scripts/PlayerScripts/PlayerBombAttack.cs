using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombAttack : MonoBehaviour
{
    [SerializeField]
    WeaponData weaponData;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    public Transform instancePoint;
    [SerializeField]
    int poolSize = 20;
    [SerializeField]
    Transform poolRoot;
    [SerializeField]
    MusicPlayer musicPlayer;

    string enemyTag = "Enemy";
    ObjectPool objectPool;

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
                    bb.SetDamage((int)weaponData.commonStats.Might + (int)weaponData.weaponStats[3].Might);
                    bb.SetSpeed(weaponData.commonStats.BulletSpeed + weaponData.weaponStats[3].BulletSpeed);
                    bb.MusicHitFx(musicPlayer);
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
