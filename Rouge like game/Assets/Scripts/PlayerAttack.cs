using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots = 2f;

	private Transform enemy;
	public GameObject bullet;
	public Transform firePoint;
	
	// Update is called once per frame

	void Start()
	{
		enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
		timeBtwShots = startTimeBtwShots;
	}


	void Update()
    {
        if (timeBtwShots <= 0)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots;

		} else
		{
			timeBtwShots -= Time.deltaTime;
		}
    }
}
