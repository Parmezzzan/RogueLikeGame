using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemy;

    public Sprite spriteImage;

    [SerializeField]
    string targetTag = "Player";

    private Transform target = null;
    void Start()
    {
        spriteImage = enemy.sprite;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            target = collision.transform;
            collision.gameObject.GetComponent<PlayerData>().TakeDamage(enemy.attack);
            InvokeRepeating("TakeDamage", enemy.repeatDamageTime, enemy.repeatDamageTime);
        }
    }
    private void TakeDamage()
    {
        if(Vector3.Distance(transform.position, target.position) < enemy.closeDistance)
        {
            target.gameObject.GetComponent<PlayerData>().TakeDamage(enemy.attack);
        }
        else
        {
            target = null;
            StopAllCoroutines();
        }
    }
}
