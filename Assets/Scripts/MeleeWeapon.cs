using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

    public Transform attackPoint;
    public float attackRadius;

    public override void Attack()
    {
        Debug.Log("Attacking");
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);
        foreach(var hit in hits)
        {
            if(hit.tag == "Enemy")
            {
                Debug.Log("Hit enemy");
                hit.GetComponent<Enemy>().TakeDamage(weaponStats.damage);
            }
        }
    }
}
