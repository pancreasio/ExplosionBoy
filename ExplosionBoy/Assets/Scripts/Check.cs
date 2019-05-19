using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public bool isTrigger;
    string dtest;

    private void Awake()
    {
        isTrigger = false;
    }
    private void Update()
    {
        Debug.Log(this.name + "  " + isTrigger + "  " + dtest);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag !="Check")
        {
            isTrigger = true;
        }
        dtest = other.tag;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Check")
        {
            isTrigger = false;
        }
        dtest = other.tag;
    }
}
