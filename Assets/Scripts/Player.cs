using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    public float attackRadius = .5f;
    public int maxHealth = 100;
    public int currentHealth;
    public int tokens;

    float movement;
    Vector3 movingRight = new Vector3(0f, 0f, 0f);
    Vector3 movingLeft = new Vector3(0f, 180f, 0f);

    Animator animator;
    Shovel shovel;
    WeaponSlot weaponSlot;

    void Start()
    {
        shovel = GetComponentInChildren<Shovel>(true);
        weaponSlot = GetComponentInChildren<WeaponSlot>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        tokens = 0;
    }

    void FixedUpdate()
    {

        movement = Input.GetAxisRaw("Horizontal");
        if (movement != 0)
            Move();

        if (Input.GetButtonDown("Fire1"))
            Attack();

        if (Input.GetButtonDown("Fire2"))
            Dig();

        animator.SetFloat("Movement", Mathf.Abs(movement));

    }

    void Dig()
    {
        animator.SetTrigger("Dig");
        shovel.Dig();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        weaponSlot.currentWeapon.Attack();
        //weaponSlot.currentWeapon.GetComponent<Weapon>().Attack();
    }

    void Move()
    {
        if (movement > 0)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(transform.position.x + movement, transform.position.y),
            speed * Time.deltaTime);
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }


}
