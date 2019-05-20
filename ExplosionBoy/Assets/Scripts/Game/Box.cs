using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject door;

    private void Awake()
    {
        door = null;
    }

    private void OnDestroy()
    {
        if (door!=null)
        {
            Instantiate(door, transform.position,Quaternion.identity);
        }
    }
}
