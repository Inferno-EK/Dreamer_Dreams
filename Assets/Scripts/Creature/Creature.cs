using UnityEngine;
public class Creature
{    
    public int Id { get; }
    public string Name { get; }
    public bool IsAlife { get; protected set; }
    public Characteristics Characteristics { get; protected set; }
    public Weapon ThisWeapon { get; protected set; }
    public int Health
    {
        get
        {
            return _health;
        }
        protected set 
        {
            IsAlife = value > 0;
            _health = value;
            if (!IsAlife) _health = 0;
            if (_health > _maxHealth) _health = _maxHealth;
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

    protected int _maxHealth;
    protected int _maxEnergy;


    private int _energy;
    private int _health;
}

