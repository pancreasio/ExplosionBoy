using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public bool isTrigger;

    private void Awake()
    {
        isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag !="Check")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Check")
        {
            isTrigger = false;
        }
    }
}
