using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject door;
    public void explode()
    {
        if (door != null)
        {
            Instantiate(door, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
