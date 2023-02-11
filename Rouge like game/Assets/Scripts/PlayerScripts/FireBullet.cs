using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private string tagEnemy = "Enemy";
    [SerializeField]
    private int damage = 20;
    [SerializeField]
    private float speed = 2f;

    private float angle = 0f;
    private GameObject targetAround;
    void Update()
    {
        angle += Time.deltaTime * speed * 15; 
        transform.position = targetAround.transform.position + Vector3.up * 1.2f;
        transform.RotateAround(targetAround.transform.position, Vector3.forward, angle);
        transform.rotation = Quaternion.identity;
    }
    public void SetTargetPoint(GameObject targetAround)
    {
        this.targetAround = targetAround;
    }
    public void SetDamage(int newGamage)
    {
        damage = newGamage;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void SetStartAngle(float a) 
    {
        angle = a;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagEnemy))
            collision.GetComponent<Enemy_HP>().TakeDamage(damage);
    }
}
