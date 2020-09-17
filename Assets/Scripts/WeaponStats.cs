using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponStats", menuName = "Weapon Stats")]
public class WeaponStats : ScriptableObject
{

    public string weaponName;
    public int damage;
    public int tokenCost;
    public Sprite sprite;
    public GameObject projectile;

}
