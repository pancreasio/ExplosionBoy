using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Material material;

    private void Start()
    {
        material = transform.GetComponent<Renderer>().material;
    }
    private void Update()
    {
        if (Enemy.activeEnemies <= 0)
        {
            material.color = Color.yellow;
        }
        else
        {
            material.color = Color.grey;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && Enemy.activeEnemies <= 0)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().loadGameOver();
        }
    }
}
