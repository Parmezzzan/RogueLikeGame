using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Biom", menuName = "Biom", order = 1)]
public class Biom : ScriptableObject
{
    public Sprite[] tileSprites;
    public float rareRank = 1.0f;
}
