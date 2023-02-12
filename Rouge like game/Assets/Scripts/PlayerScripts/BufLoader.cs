using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufLoader : MonoBehaviour
{
    [SerializeField]
    private PlayerBuffManager buffManager;
    void Start()
    {
        LoadBuffToPlayer();
    }
    private void LoadBuffToPlayer()
    {
        var saveFile = SaveManager.LoadSavefile();

        var buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/Armor") as PlayerBuff;
        for (int i = 0; i < saveFile.Armor; i++) buffManager.AddBuff(buff);
        
        buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/BulletSpeed") as PlayerBuff;
        for (int i = 0; i < saveFile.BulletSpeed; i++) buffManager.AddBuff(buff);

        buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/FireRate") as PlayerBuff;
        for (int i = 0; i < saveFile.FireRate; i++) buffManager.AddBuff(buff);

        buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/HealtRegen") as PlayerBuff;
        for (int i = 0; i < saveFile.HealtRegen; i++) buffManager.AddBuff(buff);

        buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/MagnetRange") as PlayerBuff;
        for (int i = 0; i < saveFile.MagnetRange; i++) buffManager.AddBuff(buff);

        buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/MaxHealth") as PlayerBuff;
        for (int i = 0; i < saveFile.MaxHealth; i++) buffManager.AddBuff(buff);

        buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/Might") as PlayerBuff;
        for (int i = 0; i < saveFile.Might; i++) buffManager.AddBuff(buff);

        buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/MoveSpeed") as PlayerBuff;
        for (int i = 0; i < saveFile.MoveSpeed; i++) buffManager.AddBuff(buff);

        buff = Resources.Load("PlayerBuff/PlayerGlobalBuffs/WeaponArea") as PlayerBuff;
        for (int i = 0; i < saveFile.WeaponArea; i++) buffManager.AddBuff(buff);
    }
}
