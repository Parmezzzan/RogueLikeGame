using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupingBuff : MonoBehaviour
{
    [SerializeField]
    PlayerBuff buff;

    private void Start()
    {
        gameObject.GetComponent<Pickup>().OnPickUP += getBuff;
    }
    public void getBuff (Transform t)
    {
        t.gameObject.GetComponent<PlayerBuffManager>().AddBuff(buff);
        gameObject.GetComponent<Pickup>().OnPickUP -= getBuff;
    }
}
