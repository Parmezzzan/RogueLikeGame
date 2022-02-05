using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;
    public Rigidbody2D rb;

    private Transform enemy;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        target = new Vector2(enemy.position.x, enemy.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
		{
            DestroyBullet();
		}
    }
	void OnTriggerEnter2D(Collider2D hitInfo)
	{
        Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
            enemy.TakeDamage(damage);
            DestroyBullet();
        }            
	}
	void DestroyBullet()
	{
        Destroy(gameObject);
	}
}


