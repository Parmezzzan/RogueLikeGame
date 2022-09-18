using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClowerBoostAtack : MonoBehaviour
{
    [SerializeField]
    PlayerBuff buff;
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
                item.gameObject.GetComponent<PlayerBuffManager>().AddBuff(buff);
        }
    }
}
