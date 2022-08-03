using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExprienseGem : MonoBehaviour
{
    [SerializeField]
    int EXPboost = 20;
    [SerializeField]
    float radius = 1.5f;
    [SerializeField]
    string targetTag = "Player";
    public void GetEXP()
    {
        var pos = transform.position;
        var colliders = Physics2D.OverlapCircleAll(pos, radius);
        foreach (var item in colliders)
        {
            if (item.gameObject.CompareTag(targetTag))
                item.gameObject.GetComponent<PlayerData>().AddEXP(EXPboost);
        }
    }
}
