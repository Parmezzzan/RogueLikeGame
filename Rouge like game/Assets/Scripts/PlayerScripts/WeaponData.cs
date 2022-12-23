using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponData : MonoBehaviour
{
    public CommonWeaponData commonStats;

    [SerializeField]
    int weaponAmount = 4;

    public List<CommonWeaponData> weaponStats = new List<CommonWeaponData>();
    [SerializeField]
    public UnityEvent DataHasUpdated;
    private void Start()
    {
        commonStats.CommonInit();
        weaponStats = new List<CommonWeaponData>(weaponAmount);
        foreach (var item in weaponStats)
            item.Init();
    }
    public struct CommonWeaponData
    {
        public float WeaponRange
            ;
        public float Stright;
        public float FireRate;
        public float BulletSpeed;

        public void CommonInit()
        {
            WeaponRange = 10.0f;
            Stright = 5.0f;
            FireRate = 1.0f;
            BulletSpeed = 2.0f;
        }
        public void Init()
        {
            WeaponRange = 0.0f;
            Stright = 0.0f;
            FireRate = 0.0f;
            BulletSpeed = 0.0f;
        }
    }
}

