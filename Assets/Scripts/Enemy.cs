using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { ROOT, SPAWN };

public class Enemy : MonoBehaviour
{

    public float speed = 2f;
    public float attackTime = 1.5f;
    public float attackDistance = 3f;
    public float attackRadius = 0.5f;
    public int maxHealth = 10;
    public int currentHealth;
    public int damage = 10;
    public int tokens = 10;

    public Transform target;
    public Transform attackPoint;

    EnemyState currentState;
    Root root;
    Animator animator;
    Collider2D coll;
    Vector2 movement;
    bool isAttacking;
    bool isDead;

    void Start()
    {
        currentState = EnemyState.ROOT;
        currentHealth = maxHealth;

        root = GetComponentInChildren<Root>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        target = GameManager.Instance.player.transform;

        StartCoroutine(root.SpawnCountdown((returnedState) => 
            { currentState = returnedState; Spawn(); }));
    }

    void Update()
    {

        if (currentHealth <= 0 && !isDead)
            Die();

        if (currentState == EnemyState.SPAWN && !isDead)
            Move();
    }

    private void Die()
    {
        isDead = true;
        GameManager.Instance.EnemyDeath(gameObject);
        StopAllCoroutines();
        animator.SetTrigger("Die");
        // Destroy(gameObject, 1f);
    }

    void Move()
    {
        if (transform.position.x - target.position.x > 0)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < attackDistance)
        {
            StartCoroutine(Attack());
        }
        else
        {
            movement = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, movement, speed * Time.deltaTime);
        }
        
    }

    IEnumerator Attack()
    {
        Debug.Log("Enemy attacking");
        animator.SetTrigger("Attack");
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);
        foreach (var hit in hits)
        {
            if (hit != null && hit.tag == "Player" && !isAttacking)
            {
                isAttacking = true;
                hit.GetComponent<Player>().TakeDamage(damage);
                yield return new WaitForSeconds(attackTime);
                isAttacking = false;
            }
        }
    }

    void Spawn()
    {
        Debug.Log("Successfully called Spawn function in parent.");
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        animator.SetTrigger("Spawn");
        root.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy taking " + damage + " damage.");
    }

    

}
