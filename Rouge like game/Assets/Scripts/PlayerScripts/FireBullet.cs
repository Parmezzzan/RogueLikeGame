using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private string tagEnemy = "Enemy";
    [SerializeField]
    private int damage = 20;
    [SerializeField]
    private float lifeTime = 4.0f;
    [SerializeField]
    private float speed = 2.0f;

    private Vector3 targetAround;
    void Update()
    {
        transform.RotateAround(targetAround, Vector3.forward, Time.deltaTime * speed);
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0.0f)
            Destroy(gameObject);
    }
    public void SetTargetPoint(Vector3 targetAround)
    {
        this.targetAround = targetAround;
    }
    public void SetDamage(int newGamage)
    {
        damage = newGamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagEnemy))
        {
            collision.GetComponent<Enemy_HP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
