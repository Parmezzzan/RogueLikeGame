using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private WeaponData weaponData;

    [SerializeField]
    List<PlayerBuff> buffs;

    public void AddBuff(PlayerBuff newBuff)
    {
        buffs.Add(newBuff);
        RealizeBuff(newBuff, true);
        if(!newBuff.isConstantBuff)
            StartCoroutine(DeleteBuff(newBuff));
    }
    private void RealizeBuff (PlayerBuff buff, bool increaseValue)
    {
        if (buff.WeaponBuff == PlayerBuff.WeaponBuffType.None)
        {
            switch (buff.BuffType)
            {
                case PlayerBuff.PlayerBuffType.FireRate:
                    weaponData.commonStats.FireRate += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    weaponData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.PlayerBuffType.MaxHealth:
                    playerData.maxHealth += increaseValue ? (int)buff.AddedValue : (int)-buff.AddedValue;
                    playerData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.PlayerBuffType.HealtRegen:
                    playerData.healthRegenerationPower += increaseValue ? (int)buff.AddedValue : (int)-buff.AddedValue;
                    playerData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.PlayerBuffType.Armor:
                    playerData.armor += increaseValue ? (int)buff.AddedValue : (int)-buff.AddedValue;
                    playerData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.PlayerBuffType.Straight:
                    weaponData.commonStats.Stright += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    weaponData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.PlayerBuffType.WeaponRange:
                    weaponData.commonStats.WeaponRange += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    weaponData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.PlayerBuffType.MoveSpeed:
                    playerData.moveSpeed += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    playerData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.PlayerBuffType.MagnetRange:
                    playerData.magnetRadius += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    playerData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.PlayerBuffType.BulletSpeed:
                    weaponData.commonStats.BulletSpeed += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    weaponData.DataHasUpdated?.Invoke();
                    return;
                default:
                    throw new System.Exception("No there Buff type in game!");
                    return;
            }
        }
        else
        {
            switch (buff.WeaponBuff)
            {
                case PlayerBuff.WeaponBuffType.FireRate:
                    var wd = weaponData.weaponStats[buff.weaponNum];
                    wd.FireRate += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    weaponData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.WeaponBuffType.Straight:
                    var wd2 = weaponData.weaponStats[buff.weaponNum];
                    wd2.Stright += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    playerData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.WeaponBuffType.BulletSpeed:
                    var wd3 = weaponData.weaponStats[buff.weaponNum];
                    wd3.BulletSpeed += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    playerData.DataHasUpdated?.Invoke();
                    return;
                case PlayerBuff.WeaponBuffType.WeaponRange:
                    var wd4 = weaponData.weaponStats[buff.weaponNum];
                    wd4.WeaponRange += increaseValue ? buff.AddedValue : -buff.AddedValue;
                    playerData.DataHasUpdated?.Invoke();
                    return;
                default:
                    throw new System.Exception("No there Buff type in game!");
                    return;
            }
        }
    }
    private IEnumerator DeleteBuff(PlayerBuff buffToDelete)
    {
        yield return new WaitForSeconds(buffToDelete.DurationSec);
        RealizeBuff(buffToDelete, false);
        buffs.Remove(buffToDelete);
    }
}
