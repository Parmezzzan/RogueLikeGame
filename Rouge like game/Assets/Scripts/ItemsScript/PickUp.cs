using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    string pickupTag = "Player";
    [SerializeField]
    UnityEvent OnPickUp;
    [SerializeField]
    bool destroyAfterPickUping = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(pickupTag))
        {
            OnPickUp?.Invoke();
            if(destroyAfterPickUping)
                Destroy(gameObject);
        }
    }
}
