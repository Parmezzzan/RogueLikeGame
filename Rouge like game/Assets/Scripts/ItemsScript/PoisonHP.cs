using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHP : MonoBehaviour
{
    [SerializeField]
    int healPower = 20;
    [SerializeField]
    float radius = 1.0f;
    [SerializeField]
    string targetTag = "Player";
    public void Heal()
    {
        var pos = transform.position;
        var colliders = Physics2D.OverlapCircleAll(pos, radius);
        foreach (var item in colliders)
        {
            if (item.gameObject.CompareTag(targetTag))
                item.gameObject.GetComponent<PlayerData>().Heal(healPower);
        }
    }
}
