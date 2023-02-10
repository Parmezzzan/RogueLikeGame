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
    private float spawnBulletDistanse = 1.2f;

    private void Start()
    {
        objectPool = new ObjectPool();
        objectPool.Init(bulletPrefab, poolSize, poolRoot);
        if (weaponData.weaponStats[1].level > 0)
            Fire();
    }
    private void Fire()
    {
        objectPool.Clear();
        for (int i = 0; i < weaponData.weaponStats[1].level; i++)
        {
            var bullet = objectPool.GetPoolObjectOrNull();
            if (bullet != null)
            {
                var angle = 360 / weaponData.weaponStats[1].level * i;

                bullet.transform.position = gameObject.transform.position + Vector3.up * spawnBulletDistanse;
                bullet.transform.RotateAround(gameObject.transform.position, Vector3.forward, angle);

                var fb = bullet.GetComponent<FireBullet>();
                fb.SetTargetPoint(gameObject);  //it's transform at move around for
                fb.GetComponent<TrailRenderer>().Clear();
                fb.SetStartAngle(angle);
                fb.SetDamage((int)(weaponData.commonStats.Might + weaponData.weaponStats[1].Might));
                fb.SetSpeed(weaponData.commonStats.BulletSpeed + weaponData.weaponStats[1].BulletSpeed);
            }
        }
    }
    public void UpdateWeaponData()
    {
        if (weaponData.weaponStats[1].level > 0) Fire();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, weaponData.commonStats.WeaponRange);
    }
}