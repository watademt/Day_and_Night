using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable", fileName = "New Consumable")]
public class Consumable : Item
{
    public float Cooldown;
    public float Duration;
}
