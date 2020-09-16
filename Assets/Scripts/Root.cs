using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{

    public int health = 3;
    public float spawnDelay = 10f;

    bool isDead;

    void Start()
    {
        //StartCoroutine("SpawnCountdown");
    }

    private void Update()
    {
        if(health == 0 && !isDead)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public IEnumerator SpawnCountdown(System.Action<EnemyState> callback)
    {
        yield return new WaitForSeconds(spawnDelay);
        //foreach(Transform child in transform.root)
        //{
        //    child.gameObject.SetActive(true);
        //}
        //transform.root.GetComponent<Animator>().SetTrigger("Spawn");
        // transform.root.GetComponent<Enemy>().currentState = EnemyState.SPAWN;

        callback(EnemyState.SPAWN);
        //enabled = false;
    }

    void Die()
    {
        // Destroy(gameObject.transform.parent.root.gameObject);
        isDead = true;
        GameManager.Instance.EnemyDeath(gameObject.transform.parent.root.gameObject);
    }

}
