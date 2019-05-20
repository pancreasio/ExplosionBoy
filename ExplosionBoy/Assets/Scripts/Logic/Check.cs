using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public bool isTrigger;

    private GameObject necessaryParent;
    private void Awake()
    {
        isTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            isTrigger = false;
        }
    }
}
