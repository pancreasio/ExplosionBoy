using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fuseTime;

    private float clock;
    private void Start()
    {
        clock = 0;
        float offsetZ = Mathf.Abs(transform.position.z) - Mathf.Floor(Mathf.Abs(transform.position.z));
        float offsetX = Mathf.Abs(transform.position.x) - Mathf.Floor(Mathf.Abs(transform.position.x));

        if (offsetZ >= 0.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Mathf.Abs(0.5f - offsetZ));
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Mathf.Abs(0.5f - offsetZ));
        }

        if (offsetX >= 0.5)
        {
            transform.position = new Vector3(transform.position.x + Mathf.Abs(0.5f - offsetX), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - Mathf.Abs(0.5f - offsetX), transform.position.y, transform.position.z);
        }

    }

    private void Update()
    {
        clock += Time.deltaTime;

        if (clock >= fuseTime)
        {
            Explode();
        }
    }

    private void Explode()
    {
        //aycastHit hitUp, hitDown, hitLeft, hitRight;
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitUp, 1.0f);
        Physics.Raycast(transform.position, -transform.forward, out RaycastHit hitDown, 1.0f);
        Physics.Raycast(transform.position, -transform.right, out RaycastHit hitLeft, 1.0f);
        Physics.Raycast(transform.position, transform.right, out RaycastHit hitRight, 1.0f);

        if (hitUp.transform != null && hitUp.transform.tag != "Wall")
        {
            Debug.Log(hitUp.transform.tag);
            Destroy(hitUp.transform.gameObject);
        }

        if (hitDown.transform != null && hitDown.transform.tag != "Wall")
        {
            Debug.Log(hitDown.transform.tag);
            Destroy(hitDown.transform.gameObject);
        }

        if (hitRight.transform != null && hitRight.transform.tag != "Wall")
        {
            Debug.Log(hitRight.transform.tag);
            Destroy(hitRight.transform.gameObject);
        }

        if (hitLeft.transform != null && hitLeft.transform.tag != "Wall")
        {
            Debug.Log(hitLeft.transform.tag);
            Destroy(hitLeft.transform.gameObject);
        }
        Destroy(this.gameObject);
    }
}
