using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShealdAttack : MonoBehaviour
{
    [SerializeField]
    private float radius = 4.0f;
    [SerializeField]
    private float fireRate = 1.0f;
    [SerializeField]
    private string enemyTag = "Enemy";
    [SerializeField]
    private FireBullet bulletPrefab;

    private void Start()
    {
        InvokeRepeating("Fire", 0.5f, 1.0f / fireRate);
    }
    private void Fire()
    {
        var vector = new Vector3(Random.Range(-1.0f , 1.0f), Random.Range(-1.0f, 1.0f), 0.0f) * radius;
        var bullet = Instantiate(bulletPrefab, transform.position + vector, Quaternion.identity);
        bullet.SetTargetPoint(transform.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}