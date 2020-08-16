using UnityEngine;

namespace Enums
{
    public enum Derection
    {
        Left = 1,
        Right = -1
    }


    public enum AllDerection 
    {
        Left,
        Right,
        Up,
        Down
    }

    static public class VectorDerections 
    {

        static public Vector2[] VectorDerection =
         {
        new Vector2(1, 0),
        new Vector2(-1, 0),
        new Vector2(0, 1),
        new Vector2(0, -1)
        }; 
    }

    public enum Settings
    { 
        ScreenSize
    }

    public enum Temperaments
    {
        Choleric,
        Sanguine,
        Phlegmatic,
        Melancholic
    }

    public enum CharacteristicsValues
    {
        Strength,
        Dexterity,
        Intelligence,
        Endurance,
        Wisdom,
        Luck, 
        Health, 
        Energy
    }

    public enum Genger 
    {
        Male,
        Female
    }

    public enum WeaponAbilites
    { 
        CommonAttack,
        Defence,
        SpecialAttack,
        Combination,
        Annihilation
    }


}
