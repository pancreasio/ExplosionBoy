using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum movement
    {
        up, down, left, right, none
    }
    enum fsm
    {
        random, chase
    }

    public static int activeEnemies;

    public float visionRange;
    public float speed;
    public float correctionSpeed;
    public float changeDirectionTime;
    public float snapThreshold;
    public GameObject lCheck;
    public GameObject rCheck;
    public GameObject uCheck;
    public GameObject dCheck;


    private fsm actualState;
    private movement currentMovement;
    private movement chaseMovement;
    private List<movement> possibleMovements;
    private int possibleMovementsCount;
    private float changeDirectionClock;
    private Check lCheckBool;
    private Check rCheckBool;
    private Check uCheckBool;
    private Check dCheckBool;
    private void Start()
    {
        possibleMovements = new List<movement>();
        actualState = fsm.random;
        currentMovement = movement.none;
        chaseMovement = movement.none;
        changeDirectionClock = 0;
        lCheckBool = lCheck.GetComponent<Check>();
        rCheckBool = rCheck.GetComponent<Check>();
        uCheckBool = uCheck.GetComponent<Check>();
        dCheckBool = dCheck.GetComponent<Check>();
}
    private void Update()
    {
        possibleMovements.Clear();
        possibleMovementsCount = 0;
        changeDirectionClock += Time.deltaTime;

        //-----------possible movement raycasts-----------------
        //Physics.Raycast(transform.position, transform.forward, out RaycastHit moveUp, 0.7f);
        //Physics.Raycast(transform.position, -transform.forward, out RaycastHit moveDown, 0.7f);
        //Physics.Raycast(transform.position, -transform.right, out RaycastHit moveLeft, 0.7f);
        //Physics.Raycast(transform.position, transform.right, out RaycastHit moveRight, 0.7f);

        //----------player seeking raycasts---------------------
        Physics.Raycast(transform.position, transform.forward, out RaycastHit viewUp, visionRange);
        Physics.Raycast(transform.position, -transform.forward, out RaycastHit viewDown, visionRange);
        Physics.Raycast(transform.position, -transform.right, out RaycastHit viewLeft, visionRange);
        Physics.Raycast(transform.position, transform.right, out RaycastHit viewRight, visionRange);

        //----------player seen check--------------------------
        if (viewUp.transform != null && viewUp.transform.tag == "Player")
        {
            chaseMovement = movement.up;
            actualState = fsm.chase;
        }
        else
        {
            if (viewDown.transform != null && viewDown.transform.tag == "Player")
            {
                chaseMovement = movement.down;
                actualState = fsm.chase;
            }
            else
            {
                if (viewLeft.transform != null && viewLeft.transform.tag == "Player")
                {
                    chaseMovement = movement.left;
                    actualState = fsm.chase;
                }
                else
                {
                    if (viewRight.transform != null && viewRight.transform.tag == "Player")
                    {
                        chaseMovement = movement.right;
                        actualState = fsm.chase;
                    }
                    else
                    {
                        chaseMovement = movement.none;
                        actualState = fsm.random;
                    }
                }
            }
        }

        //---------possible movement checks--------------------
        if (!uCheckBool.isTrigger)
        {
            possibleMovements.Insert(possibleMovementsCount, movement.up);
            possibleMovementsCount++;
        }
        else
        {
            if (currentMovement == movement.up)
            {
                currentMovement = movement.none;
                changeDirectionClock = 0;
            }
        }

        if (!dCheckBool.isTrigger)
        {
            possibleMovements.Insert(possibleMovementsCount, movement.down);
            possibleMovementsCount++;
        }
        else
        {
            if (currentMovement == movement.down)
            {
                currentMovement = movement.none;
                changeDirectionClock = 0;
            }
        }

        if (!lCheckBool.isTrigger)
        {
            possibleMovements.Insert(possibleMovementsCount, movement.left);
            possibleMovementsCount++;
        }
        else
        {
            if (currentMovement == movement.left)
            {
                currentMovement = movement.none;
                changeDirectionClock = 0;
            }
        }

        if (!rCheckBool.isTrigger)
        {
            possibleMovements.Insert(possibleMovementsCount, movement.right);
            possibleMovementsCount++;
        }
        else
        {
            if (currentMovement == movement.right)
            {
                currentMovement = movement.none;
                changeDirectionClock = 0;
            }
        }


        //----------FSM-----------------------
        switch (actualState)
        {
            case fsm.random:
                if (possibleMovementsCount == 0)
                {
                    currentMovement = movement.none;
                }
                else
                {
                    if (changeDirectionClock >= changeDirectionTime)
                    {
                        currentMovement = possibleMovements[Random.Range(0, possibleMovementsCount)];
                        changeDirectionClock = 0;
                    }
                }
                break;
            case fsm.chase:
                changeDirectionClock = 0;
                currentMovement = chaseMovement;
                break;
        }

        //--------actual movement--------------
        float offsetZ = Mathf.Abs(transform.position.z) - Mathf.Floor(Mathf.Abs(transform.position.z));
        float offsetX = Mathf.Abs(transform.position.x) - Mathf.Floor(Mathf.Abs(transform.position.x));

        switch (currentMovement)
        {
            case movement.up:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
                if (Mathf.Abs(0.5f - offsetX) > snapThreshold)
                {
                    if (offsetX >= 0.5)
                    {
                        transform.position = new Vector3(transform.position.x + correctionSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x - correctionSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    if (offsetX >= 0.5)
                    {
                        transform.position = new Vector3(transform.position.x + Mathf.Abs(0.5f - offsetX), transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x - Mathf.Abs(0.5f - offsetX), transform.position.y, transform.position.z);
                    }
                }
                break;
            case movement.down:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
                if (Mathf.Abs(0.5f - offsetX) > snapThreshold)
                {
                    if (offsetX >= 0.5)
                    {
                        transform.position = new Vector3(transform.position.x + correctionSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x - correctionSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    if (offsetX >= 0.5)
                    {
                        transform.position = new Vector3(transform.position.x + Mathf.Abs(0.5f - offsetX), transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x - Mathf.Abs(0.5f - offsetX), transform.position.y, transform.position.z);
                    }
                }
                break;
            case movement.left:
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                if (Mathf.Abs(0.5f - offsetZ) > snapThreshold)
                {
                    if (offsetZ >= 0.5)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + correctionSpeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - correctionSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    if (offsetZ >= 0.5)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Mathf.Abs(0.5f - offsetZ));
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Mathf.Abs(0.5f - offsetZ));
                    }
                }
                break;
            case movement.right:
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                if (Mathf.Abs(0.5f - offsetZ) > snapThreshold)
                {
                    if (offsetZ >= 0.5)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + correctionSpeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - correctionSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    if (offsetZ >= 0.5)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Mathf.Abs(0.5f - offsetZ));
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Mathf.Abs(0.5f - offsetZ));
                    }
                }
                break;
            case movement.none:
                break;
        }
    }
    private void OnDestroy()
    {
        activeEnemies--;
    }
}
