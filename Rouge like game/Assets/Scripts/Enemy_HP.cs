using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    [SerializeField]
    private GameObject expSoulSphere;

    public int health = 100;

    public GameObject deathEffect;

    public void TakeDamage (int damage)
	{
        health -= damage;
        
        if (health <= 0)
		{
            Die();
		}
	}

    void Die ()
	{
        Destroy(gameObject);
        GameObject deathEffectIns = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(expSoulSphere, transform.position, Quaternion.identity);
        Destroy(deathEffectIns, 2f);
    }
}
