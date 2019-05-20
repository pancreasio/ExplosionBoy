using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void loadGame()
    {
        GameObject.Find("Game Manager").GetComponent<GameManager>().loadGame();
    }

    public void exitGame()
    {
        GameObject.Find("Game Manager").GetComponent<GameManager>().exitGame();
    }

    public void loadMenu()
    {
        GameObject.Find("Game Manager").GetComponent<GameManager>().loadMenu();
    }
}
