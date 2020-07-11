using Enums;
public struct Characteristics
{
    public Temperaments Temperament;
    public Energy ThisEnergy;
    public Health ThisHealth;

    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public int Endurance;

    public float Wisdom;
    public float Luck;

    public Characteristics(float scaleFactor)
    {
        Strength = 0;
        Dexterity = 0;
        Intelligence = 0;
        Endurance = 0;
        Wisdom = 0;
        Luck = 0;
        Temperament = Temperaments.Choleric;
        ThisEnergy = new Energy(0);
        ThisHealth = new Health(0);
        Randomising(scaleFactor);
    }

    public void Randomising(float scaleFactor)
    {
        System.Random random = new System.Random();

        const int min_Strength = 1;
        const int max_Strength = 10;
        Strength = (int)(random.Next(min_Strength, max_Strength) * scaleFactor);

        const int min_Dexterity = 1;
        const int max_Dexterity = 10;
        Dexterity = (int)(random.Next(min_Dexterity, max_Dexterity) * scaleFactor);

        const int min_Intelligence = 1;
        const int max_Intelligence = 10;
        Intelligence = (int)(random.Next(min_Intelligence, max_Intelligence) * scaleFactor);

        const int min_Endurance = 1;
        const int max_Endurance = 10;
        Endurance = (int)(random.Next(min_Endurance, max_Endurance) * scaleFactor);

        const float min_Wisdom = 0;
        const float max_Wisdom = 0.5f;
        Wisdom = (int)(random.Next((int)(min_Wisdom * 100), (int)(max_Wisdom * 100)) * scaleFactor) / 100;

        const float min_Luck = 0;
        const float max_Luck = 2;
        Luck = (int)(random.Next((int)(min_Luck * 100), (int)(max_Luck * 100)) * scaleFactor) / 100;

        Temperament = (Temperaments)(random.Next(0, 4));

        const int min_Health = 100;
        const int max_Health = 200;
        ThisHealth = new Health((int)(random.Next(min_Health, max_Health) * scaleFactor));

        const int min_Energy= 100;
        const int max_Energy = 200;
        ThisEnergy = new Energy((int)(random.Next(min_Energy, max_Energy) * scaleFactor));
    }

    public void Upgrate(CharacteristicsValues WhatToChange, int Scale)
    {
        switch (WhatToChange)
        {
            case CharacteristicsValues.Strength:
                Strength += Scale;
                break;
            case CharacteristicsValues.Dexterity:
                Dexterity += Scale;
                break;
            case CharacteristicsValues.Intelligence:
                Intelligence += Scale;
                break;
            case CharacteristicsValues.Endurance:
                Endurance += Scale;
                break;
            case CharacteristicsValues.Wisdom:
                Wisdom += 0.1f * Scale;
                break;
            case CharacteristicsValues.Luck:
                Luck += 0.1f * Scale;
                break;
        }

    }
}

