using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;
    public float lifeTime = 2f;
    public int damage = 30;

    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	public void Start()
	{
        Invoke("HitTarget", lifeTime);
	}

	// Update is called once per frame
	void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }



	void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(effectIns, 2f);

        Damage(target);

        Destroy(gameObject);
    }

    void Damage (Transform enemy)
	{
        Enemy_HP e = enemy.GetComponent<Enemy_HP>();
        if (e != null)
		{
           e.TakeDamage(damage);
        }
        
    }

   
}