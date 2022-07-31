using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClowerBoostAtack : MonoBehaviour
{
    [SerializeField]
    int attackRateBoost = 20;
    [SerializeField]
    float time = 20;
    [SerializeField]
    float radius = 1.5f;
    [SerializeField]
    string targetTag = "Player";
    public void AttackRate()
    {
        var pos = transform.position;
        var colliders = Physics2D.OverlapCircleAll(pos, radius);
        foreach (var item in colliders)
        {
            if (item.gameObject.CompareTag(targetTag))
                item.gameObject.GetComponent<SkillsManager>().AttackRate(attackRateBoost, time);
        }
    }
}
