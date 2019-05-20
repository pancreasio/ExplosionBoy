using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int maxLives, enemies, boxes;

    private int lives, countedAliveEnemies, killedEnemies;
    private GameObject spawner;
    static GameObject managerInstance;
    private GameObject playerReference;
    private Scene currentScene;
    private bool spawned;

    private void Awake()
    {
        if (managerInstance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            managerInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
            spawned = false;
        }
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
    public void loadGame()
    {
        spawned = false;
        lives = maxLives;
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }

    public void loadGameOver()
    {
        SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void reloadGame()
    {
        spawned = false;
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        switch (currentScene.name)
        {
            case "game":
                Debug.Log(Enemy.activeEnemies);
                if (!spawned)
                {
                    GameObject.Find("Spawner").GetComponent<Spawner>().spawnStuff(17, 17, 30, enemies);
                    playerReference = GameObject.Find("Spawner").GetComponent<Spawner>().playerReference;
                    spawned = true;
                    countedAliveEnemies = enemies;
                }
                else
                {
                    if (playerReference == null)
                    {
                        lives--;
                        reloadGame();
                    }
                    if (lives <= 0)
                    {
                        loadGameOver();
                    }
                    if (Enemy.activeEnemies < countedAliveEnemies)
                    {
                        killedEnemies += countedAliveEnemies - Enemy.activeEnemies;
                        countedAliveEnemies = Enemy.activeEnemies;
                    }
                    if (countedAliveEnemies <= 0)
                    {
                        loadGameOver();
                    }
                }
                break;

            case "menu":
                break;

            case "gameOver":
                break;
        }
    }

}
