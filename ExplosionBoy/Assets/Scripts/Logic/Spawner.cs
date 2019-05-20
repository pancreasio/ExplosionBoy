using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject box;
    public GameObject enemy;

    private void Start()
    {
        spawnStuff(17, 17, 7, 0);
    }

    public void spawnStuff(int xLimit, int zLimit, int ammountOfBoxes, int ammountOfEnemies)
    {
        int stuff = ammountOfBoxes + ammountOfEnemies;

        while (stuff > 0)
        {
            Vector3 targetPos;
            if (ammountOfBoxes > 0)
            {
                while (!spawnBox(targetPos = new Vector3(Random.Range(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.x) + xLimit) + 0.5f, 0.5f, Random.Range(Mathf.FloorToInt(transform.position.z), Mathf.FloorToInt(transform.position.z) + zLimit) + 0.5f)))
                {

                }
                Debug.Log(targetPos);
                ammountOfBoxes--;
                stuff--;
            }

            if (ammountOfEnemies > 0)
            {
                while (!spawnEnemy(targetPos = new Vector3(Random.Range(0, xLimit), 0.5f, Random.Range(0, zLimit)))) { }
                ammountOfEnemies--;
                stuff--;
            }
        }
    }

    private bool spawnBox(Vector3 position)
    {
        if (Physics.CheckSphere(position, 0.1f))
        {
            return false;
        }
        else
        {
            Instantiate(box, position, Quaternion.identity);
            return true;
        }
    }

    private bool spawnEnemy(Vector3 position)
    {
        if (Physics.CheckSphere(position, 0.5f))
        {
            return false;
        }
        else
        {
            Instantiate(enemy, position, Quaternion.identity);
            return true;
        }
    }
}
