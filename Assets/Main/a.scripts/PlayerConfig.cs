using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    [Header("Data")]
    public int Level;
    public string Name;
    public Sprite Icon;

    [Header("Values")]
    public float CurrentHealth;
    public float MaxHealth;
    public float Armor;
    public float MaxArmor;
    public float Energy;
    public float MaxEnergy;
    public float CriticalChance;
    public float CriticalDamage;

    [Header("Upgrage Values")]
    public float HealthMaxUpgrage;
    public float ArmorMaxUpgrage;
    public float EnergyMaxUpgrage;
    public float CritialMaxUpgrage;

    [Header("Extra")]
    public bool Unlocked;
    public float UnlockCost;
    public float UpgrageCost;
    [Range(0, 100f)]
    public int UpgrageMultiplier;

    public void ResetPlayerStats()
    {
        CurrentHealth = MaxHealth;
        Armor = MaxArmor;
        Energy = MaxEnergy;
    }

}
