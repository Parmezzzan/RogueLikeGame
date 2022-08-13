using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointAttack : MonoBehaviour
{
    [SerializeField]
    private float range = 11.0f;
    [SerializeField]
    private float fireRate = 4.0f;
    [SerializeField]
    private string enemyTag = "Enemy";
    [SerializeField]
    private PointBullet bulletPrefab;
    [SerializeField]
    private Transform firePoint;

    private void Start()
    {
        InvokeRepeating("Fire", 0.5f, 1.0f/fireRate);
    }
    private void Fire()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, range);
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
                var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                bullet.SetTargetPoint(narrow);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
