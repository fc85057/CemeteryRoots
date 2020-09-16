using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRadius = 5f;
    public int damage = 1;

    public void Dig()
    {

        Debug.Log("Digging");

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);
        foreach (var hit in hits)
        {
            if (hit.tag == "Root")
            {
                Debug.Log("Hit root");
                hit.GetComponent<Root>().TakeDamage(damage);
            }
        }
    }
}
