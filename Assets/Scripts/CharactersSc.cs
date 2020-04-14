using UnityEngine;
using System;

public class CharactersSc
{
    public string Genger;
    public int  Strength,
                Dexterity,
                Intelligence,
                Luck,
                Wisdom,
                Endurance,
                Temperament,
                MaxHealth,
                Special_ability;
    public float Learning,
                 Critical_chance,
                 Crit_Factor;

    public int Health;

    readonly float[] MaxValue = {
        50,           //Strength
        50,          //Dexterity
        1f,         //Critical_chance
        50,        //Intelligence
        20,       //Luck
        30,      //Wisdom
        40,     //Endurance
        4,     //Temperament 
        100,  //Max_Health
        1,   //Special_ability
        1f, //Learning
        3f //Crit_Factor
    };

    readonly string[] colorTemperament = {
        "<color=red>Холерик</color>",          //Холерик
        "<color=#00FF00FF>Сангвиник</color>", //Сангвиник
        "<color=yellow>Флегматик</color>",   //Флегматик
        "<color=cyan>Меланхолик</color>"    //Меланхолик
    };

    public CharactersSc(CharactersSc other)
    {
        Strength = other.Strength;
        Dexterity = other.Dexterity;
        Critical_chance = other.Critical_chance;
        Intelligence = other.Intelligence;
        Luck = other.Luck;
        Wisdom = other.Wisdom;
        Endurance = other.Endurance;
        Temperament = other.Temperament;
        MaxHealth = other.MaxHealth;
        Special_ability = other.Special_ability;
        Learning = other.Learning;
        Crit_Factor = other.Crit_Factor;
        Health = other.MaxHealth;
        Genger = other.Genger;
    }

    public CharactersSc()
    {
        Strength = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Strength] * GlobalVaribles.ColsStep);
        Dexterity = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Dexterity] * GlobalVaribles.ColsStep);
        Critical_chance = (float)Math.Round(UnityEngine.Random.Range(0f, MaxValue[(int)Enums.ChValue.Critical_chance]), 3) * 100;
        Intelligence = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Intelligence] * GlobalVaribles.ColsStep);
        Luck = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Luck] * GlobalVaribles.ColsStep);
        Wisdom = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Wisdom] * GlobalVaribles.ColsStep);
        Endurance = UnityEngine.Random.Range(1 , (int)MaxValue[(int)Enums.ChValue.Endurance]);
        Temperament = UnityEngine.Random.Range(0, (int)MaxValue[(int)Enums.ChValue.Temperament]);
        MaxHealth = UnityEngine.Random.Range(20 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.MaxHealth] * GlobalVaribles.ColsStep);
        Special_ability = UnityEngine.Random.Range(1, (int)MaxValue[(int)Enums.ChValue.Special_ability]);
        Learning = (float)Math.Round(UnityEngine.Random.Range(0f, MaxValue[(int)Enums.ChValue.Learning]), 3) * 100;
        Crit_Factor = (float)Math.Round(UnityEngine.Random.Range(1f, MaxValue[(int)Enums.ChValue.Crit_Factor]), 2);
        Health = MaxHealth;
        Genger = UnityEngine.Random.Range(0, 2) == 1 ? "<color=#80FFFF>М</color>" : "<color=#FF00FF>Ж</color>";
    }

    public string FullText()
    {
        if (MaxHealth == Health)
            return $"Сила: {Strength}\nЛовкость: {Dexterity}\nИнтеллект: {Intelligence}\nМудрость: {Wisdom}\nМаксимальное здоровье" +
                   $": {MaxHealth}\nВыносливость: {Endurance}\nОбучаемость: {Learning}%\nУдача: {Luck}\nТемперамент: {colorTemperament[Temperament]}\n" +
                   $"Шанс усиления: {Critical_chance}%\nМножитель усиления: {Crit_Factor}\nПол: {Genger}\n";
        else
            return $"Сила: {Strength}\nЛовкость: {Dexterity}\nИнтеллект: {Intelligence}\nМудрость: {Wisdom}\nМаксимальное здоровье: {MaxHealth}\nТекущее здоровье:" +
                   $" {Health}\nВыносливость: {Endurance}\nОбучаемость: {Learning}%\nУдача: {Luck}\nТемперамент: {colorTemperament[Temperament]}\nШанс усиления:" +
                   $" {Critical_chance}%\nМножитель усиления: {Crit_Factor}\nПол: {Genger}\n";

    }

    public void SimpleRefresh()
    {
        Strength = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Strength] * GlobalVaribles.ColsStep);
        Dexterity = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Dexterity] * GlobalVaribles.ColsStep);
        Critical_chance = (float)Math.Round(UnityEngine.Random.Range(0f, MaxValue[(int)Enums.ChValue.Critical_chance]), 3) * 100;
        Intelligence = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Intelligence] * GlobalVaribles.ColsStep);
        Luck = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Luck] * GlobalVaribles.ColsStep);
        Wisdom = UnityEngine.Random.Range(1 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.Wisdom] * GlobalVaribles.ColsStep);
        Endurance = UnityEngine.Random.Range(1, (int)MaxValue[(int)Enums.ChValue.Endurance]);
        Temperament = UnityEngine.Random.Range(0, (int)MaxValue[(int)Enums.ChValue.Temperament]);
        MaxHealth = UnityEngine.Random.Range(20 * GlobalVaribles.ColsStep, (int)MaxValue[(int)Enums.ChValue.MaxHealth] * GlobalVaribles.ColsStep);
        Special_ability = UnityEngine.Random.Range(1, (int)MaxValue[(int)Enums.ChValue.Special_ability]);
        Learning = (float)Math.Round(UnityEngine.Random.Range(0f, MaxValue[(int)Enums.ChValue.Learning]), 3) * 100;
        Crit_Factor = (float)Math.Round(UnityEngine.Random.Range(1f, MaxValue[(int)Enums.ChValue.Crit_Factor]), 2);
        Health = MaxHealth;
        Genger = UnityEngine.Random.Range(0, 2) == 1 ? "<color=#80FFFF>М</color>" : "<color=#FF00FF>Ж</color>";
    }

    ////////////////////////////////////////////////
    ///                                          ///
    ///                    /\                    ///
    ///                   //\\                   ///
    ///                  //__\\                  ///
    ///                 //____\\                 ///
    ///                //______\\                ///
    ///               //________\\               ///
    ///              //__________\\              ///
    ///             //____________\\             ///
    ///            //______________\\            ///
    ///           //________________\\           ///
    ///          //__________________\\          ///
    ///         //____________________\\         ///
    ///        //______________________\\        ///
    ///       //________________________\\       ///
    ///      //__________________________\\      ///
    ///     //____________________________\\     ///
    ///    //______________________________\\    ///
    ///   //================================\\   ///
    ///                                          ///
    ////////////////////////////////////////////////
}
