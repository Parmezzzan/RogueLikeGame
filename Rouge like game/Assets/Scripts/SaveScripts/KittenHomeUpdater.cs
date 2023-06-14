using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittenHomeUpdater : MonoBehaviour
{
    [SerializeField]
    private PlayerBuff.PlayerBuffType type;
    [SerializeField]
    private Text text;
    [SerializeField]
    private MoneyCounterMainMenu MoneyCounter;

    private void Start()
    {
        var file = SaveManager.LoadSavefile();
        switch (type)
        {
            case PlayerBuff.PlayerBuffType.Armor:
                text.text = file.Armor.ToString();
                break;
            case PlayerBuff.PlayerBuffType.BulletSpeed:
                text.text = file.BulletSpeed.ToString();
                break;
            case PlayerBuff.PlayerBuffType.FireRate:
                text.text = file.FireRate.ToString();
                break;
            case PlayerBuff.PlayerBuffType.HealtRegen:
                text.text = file.HealtRegen.ToString();
                break;
            case PlayerBuff.PlayerBuffType.MagnetRange:
                text.text = file.MagnetRange.ToString();
                break;
            case PlayerBuff.PlayerBuffType.MaxHealth:
                text.text = file.MaxHealth.ToString();
                break;
            case PlayerBuff.PlayerBuffType.MoveSpeed:
                text.text = file.MoveSpeed.ToString();
                break;
            case PlayerBuff.PlayerBuffType.Might:
                text.text = file.Might.ToString();
                break;
            case PlayerBuff.PlayerBuffType.WeaponRange:
                text.text = file.WeaponArea.ToString();
                break;
            default:
                return;
        }
    }
    public void Upgrade()
    {
        var saveFile = SaveManager.LoadSavefile();
        int buffLevel = SaveExtantion.GetBuffLevel(saveFile, type);
        int cost = (int)(buffLevel * 1.4f * 100);

        if (MoneyCounter.money > cost)
        {
            MoneyCounter.increaseMoney(100);

            switch (type)
            {
                case PlayerBuff.PlayerBuffType.Armor:
                    saveFile.Armor++;
                    text.text = saveFile.Armor.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.BulletSpeed:
                    saveFile.BulletSpeed++;
                    text.text = saveFile.BulletSpeed.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.FireRate:
                    saveFile.FireRate++;
                    text.text = saveFile.FireRate.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.HealtRegen:
                    saveFile.HealtRegen++;
                    text.text = saveFile.HealtRegen.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.MagnetRange:
                    saveFile.MagnetRange++;
                    text.text = saveFile.MagnetRange.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.MaxHealth:
                    saveFile.MaxHealth++;
                    text.text = saveFile.MaxHealth.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.MoveSpeed:
                    saveFile.MoveSpeed++;
                    text.text = saveFile.MoveSpeed.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.Might:
                    saveFile.Might++;
                    text.text = saveFile.Might.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.WeaponRange:
                    saveFile.WeaponArea++;
                    text.text = saveFile.WeaponArea.ToString();
                    break;
                default:
                    return;
            }
            saveFile.money -= cost;
            SaveManager.Save(saveFile);
        }
    }
}
