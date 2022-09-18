using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombAttack : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData;
    [SerializeField]
    private string enemyTag = "Enemy";
    [SerializeField]
    private BombBullet bulletPrefab;
    [SerializeField]
    private Transform instancePoint;

    private void Start()
    {
        InvokeRepeating("Fire", 0.5f, 1.0f / weaponData.FireRate);
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
            foreach (var item in colliders)
            {
                if (item.CompareTag(enemyTag))
                {
                    var bullet = Instantiate(bulletPrefab, instancePoint.position, Quaternion.identity);
                    bullet.SetTargetPoint(item.transform.position);
                    bullet.SetDamage((int)weaponData.Might);
                    return;
                }
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, weaponData.WeaponAria);
    }

}
