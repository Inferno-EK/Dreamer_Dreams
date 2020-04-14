using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum ChValue : int
    {
        Strength,
        Dexterity,
        Critical_chance,
        Intelligence,
        Luck,
        Wisdom,
        Endurance,
        Temperament,
        MaxHealth,
        Special_ability,
        Learning,
        Crit_Factor
    }

    public enum WeapunClasses : int
    {
        Melee,
        Ranged,
        Magic,
        Summon
    }
}

