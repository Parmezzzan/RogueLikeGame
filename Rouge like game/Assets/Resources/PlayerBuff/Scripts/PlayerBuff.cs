using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Buffs/PlayerBuff", order = 10)]
public class PlayerBuff : ScriptableObject
{
    public enum PlayerBuffType
    {
        MaxHealth,
        HealtRegen,
        Armor,
        MoveSpeed,
        MagnetRange,
        Straight, 
        WeaponRange,
        FireRate,
        BulletSpeed
    }
    public enum WeaponBuffType
    {
        None,
        Straight,
        WeaponRange,
        FireRate,
        BulletSpeed
    }
    public PlayerBuffType BuffType;
    public bool isConstantBuff;
    public float DurationSec;
    public float AddedValue;
    public WeaponBuffType WeaponBuff = WeaponBuffType.None;
    public int weaponNum = 1;
}
