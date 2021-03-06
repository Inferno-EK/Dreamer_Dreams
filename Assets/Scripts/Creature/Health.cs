﻿public class Health
{
    public int MaxHealth { get; set; }
    public int NowHealth { get; set; }
    public void Heal(float Percent)
    {
        NowHealth += (int) (MaxHealth * Percent);
        if (NowHealth < 0) NowHealth = 0;
        if (NowHealth > MaxHealth) NowHealth = MaxHealth;
    }

    public Health(int maxHealth)
    {
        MaxHealth = maxHealth;
        NowHealth = MaxHealth;
    }
}
