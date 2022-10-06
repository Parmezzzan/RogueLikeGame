using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardLevel", menuName = "Buffs/CardLevel", order = 1)]
public class CardLevel : ScriptableObject
{
    public string Name;
    public string Info;
    public string Text;
    public Sprite Backgroung;
    public Sprite Icon;
    public int StarsNum;
    public List<PlayerBuff> CardBuffs;
}
