using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Gun
}

public enum WeaponRarity
{
    Common,
    Rare,
    Epic,
    Legendary,
}

[CreateAssetMenu(menuName = "Items/Weapon")]
public class ItemWeapon: ItemDara
{
    [Header("Data")]
    public WeaponType WeaponType;
    public WeaponRarity Rarity;

    [Header("Settings")]
    public float Damage;
    public float RequiredEnergy;
    public float TimeBetweenShots;
    public float MinSpread;
    public float MaxSpread;
}