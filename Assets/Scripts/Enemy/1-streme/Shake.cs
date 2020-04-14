﻿using UnityEngine;

public class Shake : IEnemy
{
    const int Id = 1;

    Sprite sprite;
    int MaxHealth;
    int Health;
    int Power;
    bool Alife;



    public bool HaveSpecialAbility()
    {
        return false;
    }

    public string Name()
    {
        return "Змея";
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public int GetHealth()
    {
        return Health;
    }

    public float PersentHealth()
    {
        return (float)System.Math.Round((double)Health / (double)MaxHealth * 100, 2);
    }

    public Shake()
    {
        sprite = Resources.Load<Sprite>("Image/Fight/Mobs/" + "Shake");
        MaxHealth = Random.Range(50, GlobalVaribles.ColsStep * 100);
        Health = MaxHealth;
        Alife = true;
        Power = Random.Range(1, GlobalVaribles.ColsStep * 10);
    }

    public int GetId() { return Id; }
    public void Damaging(int OtherPower)
    {
        Health -= OtherPower;
        Alife = Health > 0;
        if (Health < 0) Health = 0;
    }

    public int GetPower() { return Power; }
    public bool Life() { return Alife; }

    public void SetHealth(int HowMuch)
    {
        MaxHealth = HowMuch;
        Health = HowMuch;
    }

    public void SetPower(int HowMuch)
    {
        Power = HowMuch;
    }
}