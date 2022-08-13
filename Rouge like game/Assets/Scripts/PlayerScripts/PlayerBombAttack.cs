using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombAttack : MonoBehaviour
{
    [SerializeField]
    private float range = 14.0f;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private string enemyTag = "Enemy";
    [SerializeField]
    private BombBullet bulletPrefab;
    [SerializeField]
    private Transform instancePoint;

    private void Start()
    {
        InvokeRepeating("Fire", 0.5f, 1.0f / fireRate);
    }
    private void Fire()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, range);
        if (colliders.Length > 1)
        {
            foreach (var item in colliders)
            {
                if (item.CompareTag(enemyTag))
                {
                    var bullet = Instantiate(bulletPrefab, instancePoint.position, Quaternion.identity);
                    bullet.SetTargetPoint(item.transform.position);
                    return;
                }
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }



}
