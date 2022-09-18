using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Buffs/PlayerBuff", order = 1)]
public class PlayerBuff : ScriptableObject
{
    public enum PlayerBuffType
    {
        //character
        MaxHealth,
        HealtRegeneration,
        Armor,
        MoveSpeed,
        MagnetPower, //aria of character puckup's power
                     //weapon
        Migth, //power of ALL weapon
        WeaponArea,
        FireRate, //speed of weapon
                  //bullet
        BulletSpeed
    }
    public PlayerBuffType BuffType;
    public bool isConstantBuff;
    public float DurationSec;
    public float AddedValue;
}
