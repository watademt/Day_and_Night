using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/character base stats", fileName = "New Character Base Stats")]
public class BaseCharacterStats : ScriptableObject
{
    public int BaseHealth;
    public int BaseAtackDamage;
    public float BaseMovingSpeed;
}
