using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject box;
    public GameObject enemy;
    public GameObject player;
    public GameObject playerReference;
    public GameObject door;
   
    public void spawnStuff(int xLimit, int zLimit, int ammountOfBoxes, int ammountOfEnemies)
    {
        bool doorAsigned = false;
        int stuff = ammountOfBoxes + ammountOfEnemies;
        Enemy.activeEnemies += ammountOfEnemies;
        GameObject boxReference = new GameObject();
        Vector3 position; 

        while (stuff > 0)
        {            
            if (ammountOfBoxes > 0)
            {
                while (!spawnBox(position = new Vector3(Random.Range(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.x) + xLimit) + 0.5f,
                    0.5f,
                    Random.Range(Mathf.FloorToInt(transform.position.z), Mathf.FloorToInt(transform.position.z) + zLimit) + 0.5f)))
                {

                }
                boxReference = Instantiate(box, position, Quaternion.identity);
                if (!doorAsigned)
                {
                    boxReference.GetComponent<Box>().door = door;
                    doorAsigned = true;
                }
                ammountOfBoxes--;
                stuff--;
            }

            if (ammountOfEnemies > 0)
            {
                while (!spawnEnemy(new Vector3(Random.Range(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.x) + xLimit) + 0.5f,
                    0.5f,
                    Random.Range(Mathf.FloorToInt(transform.position.z), Mathf.FloorToInt(transform.position.z) + zLimit) + 0.5f)))
                {

                }
                ammountOfEnemies--;
                stuff--;
            }
        }
        while (!spawnPlayer(new Vector3(Random.Range(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.x) + xLimit) + 0.5f, 0.5f, Random.Range(Mathf.FloorToInt(transform.position.z), Mathf.FloorToInt(transform.position.z) + zLimit) + 0.5f)))
        {

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
            return true;
        }
    }

    private bool spawnEnemy(Vector3 position)
    {
        if (Physics.CheckSphere(position, 0.1f))
        {
            return false;
        }
        else
        {
            Instantiate(enemy, position, Quaternion.identity);
            return true;
        }
    }

    private bool spawnPlayer(Vector3 position)
    {
        if (Physics.CheckSphere(position, 0.1f))
        {
            return false;
        }
        else
        {
            playerReference = Instantiate(player, position, Quaternion.identity);
            return true;
        }
    }
    
}
