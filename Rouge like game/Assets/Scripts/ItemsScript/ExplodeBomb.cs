using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBomb : MonoBehaviour
{
    [SerializeField]
    int eachDemage = 100;
    [SerializeField]
    float radius = 10.0f;
    [SerializeField]
    string targetTag = "Enemy";

    private void Start()
    {
        gameObject.GetComponent<Pickup>().OnPickUP += explode;
    }
    public void explode (Transform t)
    {
        var pos = transform.position;
        var colliders = Physics2D.OverlapCircleAll(pos, radius);
        foreach (var item in colliders)
        {
            if (item.gameObject.CompareTag(targetTag))
                item.gameObject.GetComponent<Enemy_HP>().TakeDamage(eachDemage);
        }
        gameObject.GetComponent<Pickup>().OnPickUP -= explode;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
