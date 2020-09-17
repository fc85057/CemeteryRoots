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
    StoreManager storeManager;

    public Player player;
    int playerHealth;
    int tokens;

    public GameObject gameOverScreen;

    public bool gameOver;
    bool isPaused;

    public static GameManager Instance
    {
        get
        {
            if (instance == null && SceneManager.GetActiveScene().name == "MainGame")
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
        storeManager = GetComponent<StoreManager>();

        playerHealth = player.maxHealth;
        tokens = 0;
    }

    void Update()
    {
        playerHealth = player.currentHealth;
        uiManager.SetHealth(playerHealth);
        if(playerHealth <= 0)
        {
            if (!gameOver)
                StartCoroutine(GameOver());
            gameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            SetPause();
        }

    }

    IEnumerator GameOver()
    {
        Debug.Log("Game Over");
        player.animator.SetTrigger("Die");
        player.enabled = false;
        gameOverScreen.SetActive(true);
        yield return new WaitForSeconds(4f);
        LoadMainMenu();
    }

    public void EnemyDeath(GameObject enemy)
    {
        // tokens += enemy.GetComponent<Enemy>().tokens;
        SetTokens(enemy.GetComponent<Enemy>().tokens);
        enemyManager.RemoveEnemy(enemy);
        // uiManager.UpdateTokens(tokens);
    }

    public void SetPause()
    {
        isPaused = !isPaused;

        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;

        uiManager.SetPauseMenu(isPaused);
    }

    public int GetTokens()
    {
        return tokens;
    }

    public void SetTokens(int tokensChange)
    {
        tokens += tokensChange;
        uiManager.UpdateTokens(tokens);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AddWeapon(GameObject weapon)
    {
        storeManager.SpawnWeapon(weapon);
    }

}
