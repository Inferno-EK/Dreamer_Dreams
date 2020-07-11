using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public abstract class Weapon
{
    public string Name { get; protected set; } = "Zero";
    public string Description { get; protected set; } = "Не забудь добавить описание!!!";
    public int Id { get; protected set; } = 0;
    public float Damage { get; protected set; } = 0.01f;

    public abstract void Ability(WeaponAbilites abilite, Characteristics owner, Characteristics derection);
    public abstract bool IsCurrent(Characteristics NewOwner);
}
