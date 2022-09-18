using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    string pickupTag = "Player";
    [SerializeField]
    bool destroyAfterPickUping = true;
    [SerializeField]
    PickupBuff pickupBuff;
    [Space(15)]
    [SerializeField]
    UnityEvent OnPickUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(pickupTag))
        {
            OnPickUp?.Invoke();
            pickupBuff?.AddBuff(collision.transform);

            if(destroyAfterPickUping)
                Destroy(gameObject);
        }
    }
}
