using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponData : MonoBehaviour
{
    public CommonWeaponData commonStats;

    [SerializeField]
    int weaponAmount = 4;

    [SerializeField]
    public CommonWeaponData[] weaponStats;
    [SerializeField]
    public UnityEvent DataHasUpdated;
    
    private void Awake()
    {
        commonStats.CommonInit();

        weaponStats = new CommonWeaponData[weaponAmount];
        for (int i = 0; i < weaponAmount; i++)
            weaponStats[i] = new CommonWeaponData();

        print($"has {weaponAmount} col");
        print($"has {weaponStats.Length} stats");

        for (int i = 0; i < weaponStats.Length; i++)
            weaponStats[i].Init();
    }
    public struct CommonWeaponData
    {
        public float WeaponRange;            
        public float Might;
        public float FireRate;
        public float BulletSpeed;
        public int level;

        public void CommonInit()
        {
            level = 0;
            WeaponRange = 6.0f;
            Might = 20.0f;
            FireRate = 0.8f;
            BulletSpeed = 1.5f;
        }
        public void Init()
        {
            level = 0;
            WeaponRange = 0.0f;
            Might = 0.0f;
            FireRate = 0.0f;
            BulletSpeed = 0.0f;
        }
    }
}

