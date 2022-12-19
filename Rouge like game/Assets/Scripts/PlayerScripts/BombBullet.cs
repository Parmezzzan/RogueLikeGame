using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    [SerializeField]
    private float explodeRange = 6.0f;
    [SerializeField]
    private float speed = 15.0f;
    [SerializeField]
    private string tagEnemy = "Enemy";
    [SerializeField]
    private int damage = 15;
    [SerializeField]
    private static float ExplodeToPointRange = 0.4f;

    private Vector3 targetPoint;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPoint) < ExplodeToPointRange)
            Explode();
    }
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
    public void SetSpeed (float newSpeed)
    {
        speed = newSpeed;
    }
    private void Explode()
    {
        var col = Physics2D.OverlapCircleAll(transform.position, explodeRange);

        foreach (var item in col)
            if (item.CompareTag(tagEnemy))
                item.GetComponent<Enemy_HP>().TakeDamage(damage);

        gameObject.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRange);
    }
    public void SetTargetPoint(Vector3 target)
    {
        targetPoint = target;
    }
}
