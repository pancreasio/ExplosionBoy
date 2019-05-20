using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && Enemy.activeEnemies <= 0)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().loadGameOver();
        }
    }
}
