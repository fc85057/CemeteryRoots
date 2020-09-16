using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponStats", menuName = "Weapon Stats")]
public class WeaponStats : ScriptableObject
{

    public int damage;
    public Sprite sprite;
    public GameObject projectile;

}
