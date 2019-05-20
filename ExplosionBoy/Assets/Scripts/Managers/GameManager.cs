using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameObject managerInstance;
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
        }
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
    public void loadGame()
    {
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


}
