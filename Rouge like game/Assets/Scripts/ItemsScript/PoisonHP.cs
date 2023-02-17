using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHP : MonoBehaviour
{
    [SerializeField]
    int healPower = 20;

    private void Start()
    {
        gameObject.GetComponent<Pickup>().OnPickUP += heal;
    }

    void heal (Transform t)
    {
        t.GetComponent<PlayerData>().Heal(healPower);
        gameObject.GetComponent<Pickup>().OnPickUP -= heal;
    }
}
