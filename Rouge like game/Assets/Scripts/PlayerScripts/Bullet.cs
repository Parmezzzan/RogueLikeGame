using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;
    public float lifeTime = 2f;
    public int damage = 30;

    MusicPlayer musicPlayer;
    PoolManager poolHitFX;

    public void UpdateLifeTime(float newLifeTime) => lifeTime = newLifeTime;

    public void Seek(Transform _target) => target = _target;

    public void PoolFX(PoolManager newPoolFx) => poolHitFX = newPoolFx;

    public void MusicHitFx(MusicPlayer mp) => musicPlayer = mp;

	public void Start()=> Invoke("HitTarget", lifeTime);

	// Update is called once per frame
	void Update()
    {
        if (lifeTime < 0 || target.gameObject.active == false)         // ниче не делаем если нет таргета
        {
            gameObject.SetActive(false);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        lifeTime -= Time.deltaTime;

        if (dir.magnitude <= 0.15f) //distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

	void HitTarget()
    {
        if (target.gameObject.active == true)
        {
            musicPlayer.playSound();
            var o = poolHitFX.GetObjectFromPool();
            o.transform.position = gameObject.transform.position;
            o.GetComponent<ParticleSystem>().Emit(100);

            Damage(target);
            gameObject.SetActive(false);
        }
    }

    void Damage (Transform enemy)
	{
        Enemy_HP e = enemy.GetComponent<Enemy_HP>();
        e?.TakeDamage(damage);
    }
}