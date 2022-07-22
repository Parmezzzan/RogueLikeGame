using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemy;

    public Sprite spriteImage;

    void Start()
    {
        spriteImage = enemy.sprite;
    }
}
