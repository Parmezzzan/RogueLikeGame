using UnityEngine;

public class PlayerShealdAttack : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int poolSize = 20;
    [SerializeField]
    private Transform poolRoot;

    private ObjectPool objectPool;

    private void Start()
    {
        objectPool = new ObjectPool();
        objectPool.Init(bulletPrefab, poolSize, poolRoot);
        InvokeRepeating("Fire", 0.5f, 1.0f / weaponData.commonStats.FireRate);
    }
    private void Fire()
    {
        //var bullet = Instantiate(bulletPrefab, transform.position + vector, Quaternion.identity);
        var bullet = objectPool.GetPoolObjectOrNull();
        if (bullet != null)
        {
            var vector = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f) * weaponData.commonStats.WeaponRange;
            bullet.transform.position = transform.position + vector;
            var fb = bullet.GetComponent<FireBullet>();
            fb.SetTargetPoint(transform.position);  //it's transform at move around for
            fb.SetDamage((int)weaponData.commonStats.Stright);
            fb.SetLifeTime(4.0f);
            fb.SetSpeed(weaponData.commonStats.BulletSpeed);
        }
        else
        {
            throw new System.Exception("NULL get from pool");
        }
    }
    public void UpdateWeaponData()
    {
        CancelInvoke();
        InvokeRepeating("Fire", 0.2f, 1.0f / weaponData.commonStats.FireRate);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, weaponData.commonStats.WeaponRange);
    }
}