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
                text.text = file.Straight.ToString();
                break;
            case PlayerBuff.PlayerBuffType.WeaponRange:
                text.text = file.WeaponRange.ToString();
                break;
            default:
                return;
        }
    }
    public void Upgrade()
    {
        if (MoneyCounter.money > 100)
        {
            MoneyCounter.increaseMoney(100);

            var file = SaveManager.LoadSavefile();
            switch (type)
            {
                case PlayerBuff.PlayerBuffType.Armor:
                    file.Armor++;
                    text.text = file.Armor.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.BulletSpeed:
                    file.BulletSpeed++;
                    text.text = file.BulletSpeed.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.FireRate:
                    file.FireRate++;
                    text.text = file.FireRate.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.HealtRegen:
                    file.HealtRegen++;
                    text.text = file.HealtRegen.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.MagnetRange:
                    file.MagnetRange++;
                    text.text = file.MagnetRange.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.MaxHealth:
                    file.MaxHealth++;
                    text.text = file.MaxHealth.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.MoveSpeed:
                    file.MoveSpeed++;
                    text.text = file.MoveSpeed.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.Might:
                    file.Straight++;
                    text.text = file.Straight.ToString();
                    break;
                case PlayerBuff.PlayerBuffType.WeaponRange:
                    file.WeaponRange++;
                    text.text = file.WeaponRange.ToString();
                    break;
                default:
                    return;
            }
            file.money -= 100;
            SaveManager.Save(file);
        }
    }
}
