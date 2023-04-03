using UnityEditor.Animations;

public static class KittenChoiseMem
{
    public static kittenName nameKitten = kittenName.none;

    public enum kittenName
    {
        none,
        Wizzard,
        Archer,
        Warior
    }

    public static AnimatorController kittenAnimator;
    //common powwer stats level
    public static int MaxHealth = 0;
    public static int HealtRegen = 0;
    public static int Armor = 0;
    public static int MoveSpeed = 0;
    public static int MagnetRange = 0;
    public static int Might = 0;
    public static int FireRate = 0;
}