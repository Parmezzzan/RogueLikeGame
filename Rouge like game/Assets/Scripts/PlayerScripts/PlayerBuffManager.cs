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
        switch (buff.BuffType)
        {
            case PlayerBuff.PlayerBuffType.FireRate:
                weaponData.FireRate += increaseValue ? buff.AddedValue : -buff.AddedValue;
                weaponData.DataHasUpdated?.Invoke();
                return;
            case PlayerBuff.PlayerBuffType.MaxHealth:
                playerData.maxHealth += increaseValue ? (int)buff.AddedValue : (int)-buff.AddedValue;
                playerData.DataHasUpdated?.Invoke();
                return;
            case PlayerBuff.PlayerBuffType.HealtRegeneration:
                playerData.healthRegenerationPower += increaseValue ? (int)buff.AddedValue : (int)-buff.AddedValue;
                playerData.DataHasUpdated?.Invoke();
                return;
            case PlayerBuff.PlayerBuffType.Armor:
                playerData.armor += increaseValue ? (int)buff.AddedValue : (int)-buff.AddedValue;
                playerData.DataHasUpdated?.Invoke();
                return;
            case PlayerBuff.PlayerBuffType.Migth:
                weaponData.Might += increaseValue ? buff.AddedValue : -buff.AddedValue;
                weaponData.DataHasUpdated?.Invoke();
                return;
            case PlayerBuff.PlayerBuffType.WeaponArea:
                weaponData.WeaponAria += increaseValue ? buff.AddedValue : -buff.AddedValue;
                weaponData.DataHasUpdated?.Invoke();
                return;
            case PlayerBuff.PlayerBuffType.MoveSpeed:
                playerData.moveSpeed += increaseValue ? buff.AddedValue : -buff.AddedValue;
                playerData.DataHasUpdated?.Invoke();
                return;
            default:
                throw new System.Exception("No there Buff type in game!");
                return;
        }
    }
    private IEnumerator DeleteBuff(PlayerBuff buffToDelete)
    {
        yield return new WaitForSeconds(buffToDelete.DurationSec);
        RealizeBuff(buffToDelete, false);
        buffs.Remove(buffToDelete);
    }
}
