using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    UIManager uiManager;
    EnemyManager enemyManager;

    public Player player;
    int playerHealth;
    int tokens;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        uiManager = GetComponent<UIManager>();
        enemyManager = GetComponent<EnemyManager>();

        playerHealth = player.maxHealth;
        tokens = 0;
    }

    void Update()
    {
        playerHealth = player.currentHealth;
        uiManager.SetHealth(playerHealth);
        if(playerHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        Debug.Log("Game Over");
        player.enabled = false;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }

    public void EnemyDeath(GameObject enemy)
    {
        tokens += enemy.GetComponent<Enemy>().tokens;
        enemyManager.RemoveEnemy(enemy);
        uiManager.UpdateTokens(tokens);
    }
}
