using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float correctionSpeed;
    public float snapThreshold;
    public GameObject lCheck;
    public GameObject rCheck;
    public GameObject uCheck;
    public GameObject dCheck;

    private Check lCheckBool;
    private Check rCheckBool;
    private Check uCheckBool;
    private Check dCheckBool;

    private void Start()
    {
        lCheckBool = lCheck.GetComponent<Check>();
        rCheckBool = rCheck.GetComponent<Check>();
        uCheckBool = uCheck.GetComponent<Check>();
        dCheckBool = dCheck.GetComponent<Check>();
    }
    private void Update()
    {
        float offsetZ = Mathf.Abs(transform.position.z) - Mathf.Floor(Mathf.Abs(transform.position.z));
        float offsetX = Mathf.Abs(transform.position.x) - Mathf.Floor(Mathf.Abs(transform.position.x));
        if (Input.GetKey(KeyCode.LeftArrow) && !rCheckBool.isTrigger)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (offsetZ != 0.5)
            {
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
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && !lCheckBool.isTrigger)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (offsetZ != 0.5)
            {
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
            }
        }
        if (Input.GetKey(KeyCode.UpArrow) && !dCheckBool.isTrigger)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
            if (offsetX != 0.5)
            {
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
            }

        }
        if (Input.GetKey(KeyCode.DownArrow) && !uCheckBool.isTrigger)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
            if (offsetX != 0.5)
            {
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
            }
        }
    }
}
