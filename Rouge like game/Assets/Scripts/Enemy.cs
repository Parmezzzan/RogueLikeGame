using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemy;

    public Sprite spriteImage;

    [SerializeField]
    string targetTag = "Player";

    void Start()
    {
        spriteImage = enemy.sprite;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
            collision.gameObject.GetComponent<PlayerData>().TakeDamage(enemy.attack);
    }
}
