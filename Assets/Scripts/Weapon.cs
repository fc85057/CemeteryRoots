using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{

    public WeaponStats weaponStats;

    public abstract void Attack();

}
