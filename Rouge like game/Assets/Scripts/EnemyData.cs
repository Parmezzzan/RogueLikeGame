using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public new string name;

    public int speed;
    public int attack;
    public int health;
    public float repeatDamageTime;
    public float closeDistance;
    public int maxMoneyFarm;
    public int moneyChance;

    public RuntimeAnimatorController anim;
}
