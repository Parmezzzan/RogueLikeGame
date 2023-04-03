using UnityEditor.Animations;
using UnityEngine;

public class CharacterNum : MonoBehaviour
{
    [SerializeField]
    public KittenChoiseMem.kittenName name;
    [SerializeField]
    public AnimatorController animatorController;

    public int MaxHealth = 0;
    public int HealtRegen = 0;
    public int Armor = 0;
    public int MoveSpeed = 0;
    public int MagnetRange = 0;
    public int Might = 0;
    public int FireRate = 0;
}
