using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "UpgradeBranch", menuName = "Buffs/UpgradeBranch", order = 20)]
public class LevelUpdateBranch : ScriptableObject
{
    public string Name = "Default branch";
    public int currentLevel = 0;
    public List<CardLevel> cardsLevel;
    private int maxLevel { get { return cardsLevel.Count; } }
}
