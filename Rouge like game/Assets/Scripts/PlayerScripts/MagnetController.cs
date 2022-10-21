using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField]
    float Radius = 2.0f;
    [SerializeField]
    PlayerData playerData;

    private void Start()
    {
        Radius = playerData.magnetRadius;
    }
    public void UpdateData()
    {
        Radius = playerData.magnetRadius;
        gameObject.GetComponent<CircleCollider2D>().radius = Radius;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<IFarm>().GetFarm(playerData);
    }
}
