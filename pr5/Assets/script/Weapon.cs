using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Weapon", fileName = "New Weapon")]
public class Weapon : Item
{
    public int Damage;
    public float AttackRate;
}
