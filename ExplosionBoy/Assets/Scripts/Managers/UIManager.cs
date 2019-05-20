using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text highScoreText, scoreText;
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

    public void assignScoreText()
    {
        highScoreText.text = "Highscore: " + GameObject.Find("Game Manager").GetComponent<GameManager>().highScore;
        scoreText.text = "Score: " + GameObject.Find("Game Manager").GetComponent<GameManager>().score;
    }
}
