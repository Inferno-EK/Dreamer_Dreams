using Delegates;
using UnityEngine;
public class Creature
{
    public OnChangeHealth onChangeHealth;
    public int Id { get; }
    public string Name { get; } = "";
    public bool IsAlife { get; protected set; } = true;
    public Characteristics Characteristics { get; protected set; }
    public Weapon ThisWeapon { get; protected set; }
    public int Health
    {
        get
        {
            return Characteristics.ThisHealth.NowHealth;
        }
        protected set 
        {
            IsAlife = value > 0;
            Characteristics.ThisHealth.NowHealth = value;
            if (!IsAlife) Characteristics.ThisHealth.NowHealth = 0;
            if (Characteristics.ThisHealth.NowHealth > Characteristics.ThisHealth.MaxHealth) Characteristics.ThisHealth.NowHealth = Characteristics.ThisHealth.MaxHealth;
            onChangeHealth.Invoke(((float)Characteristics.ThisHealth.NowHealth) / Characteristics.ThisHealth.MaxHealth);
        }
    }
    public int Energy
    {
        get
        {
            return _energy;
        }
        protected set
        {
            if (value < 0) _energy = 0;
            else if (value > _maxEnergy) _energy = _maxEnergy;
            else _energy = value;
        }
    }
    public int Mood { get; protected set; }

    
    public Creature(int Id, string Name, float Scale = 1f)
    { 
        this.Id = Id;
        this.Name = Name;
        Characteristics = new Characteristics(Scale);
    }

    public bool TryToAddEnergy(int value)
    {
        int newEnergy = Energy + value;

        if (newEnergy >= 0) Energy = newEnergy;
        if (Energy > _maxEnergy) Energy = _maxEnergy;
        return newEnergy >= 0;
    }
    public void Damage(int value)
    {
        Health -= value;
    }

    protected int _maxEnergy;
    private int _energy;
}

