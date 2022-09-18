using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShealdAttack : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData;
    [SerializeField]
    private FireBullet bulletPrefab;

    private void Start()
    {
        InvokeRepeating("Fire", 0.5f, 1.0f / weaponData.FireRate);
    }
    private void Fire()
    {
        var vector = new Vector3(Random.Range(-1.0f , 1.0f), Random.Range(-1.0f, 1.0f), 0.0f) * weaponData.WeaponAria;
        var bullet = Instantiate(bulletPrefab, transform.position + vector, Quaternion.identity);
        bullet.SetTargetPoint(transform.position);
        bullet.SetDamage((int)weaponData.Might);
    }
    public void UpdateWeaponData()
    {
        CancelInvoke();
        InvokeRepeating("Fire", 0.2f, 1.0f / weaponData.FireRate);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, weaponData.WeaponAria);
    }
}