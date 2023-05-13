using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private BaseCharacterStats baseStats;

    private int maxHealth;
    private int baseDamage;
    private float baseMovementSpeed;

    private int currentHealth;

    public int MaxHealth { get => maxHealth; }
    public int BaseDamage { get => baseDamage; }
    public float BaseMovementSpeed { get => baseMovementSpeed; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Start()
    {
        ApplayStats(baseStats);
        currentHealth = maxHealth;
    }

    

    private void ApplayStats(BaseCharacterStats stats)
    {
        maxHealth = stats.BaseHealth;
        baseDamage = stats.BaseAtackDamage;
        baseMovementSpeed = stats.BaseMovingSpeed;
    }
}
