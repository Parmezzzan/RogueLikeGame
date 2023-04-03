using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenTypeChoise : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;
    [SerializeField]
    WeaponData weaponData;
    private void Awake()
    {
        KittenChoiseMem.kittenName chosenKitten = KittenChoiseMem.nameKitten;
        playerData.moveSpeed += KittenChoiseMem.MoveSpeed;
        playerData.maxHealth += KittenChoiseMem.MaxHealth;
        playerData.armor += KittenChoiseMem.Armor;
        playerData.magnetRadius += KittenChoiseMem.MagnetRange;
        playerData.healthRegenerationPower += KittenChoiseMem.HealtRegen;
        weaponData.commonStats.Might += KittenChoiseMem.Might;
        weaponData.commonStats.FireRate += KittenChoiseMem.FireRate;

        //GetComponent<Animator>().runtimeAnimatorController = KittenChoiseMem.kittenAnimator;
    }
}
