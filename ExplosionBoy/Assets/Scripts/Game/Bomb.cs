using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fuseTime;
    public float range;

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
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitUp, 1.0f);
        Physics.Raycast(transform.position, -transform.forward, out RaycastHit hitDown, 1.0f);
        Physics.Raycast(transform.position, -transform.right, out RaycastHit hitLeft, 1.0f);
        Physics.Raycast(transform.position, transform.right, out RaycastHit hitRight, 1.0f);

        if (hitUp.transform != null && (hitUp.transform.tag != "Wall" || hitUp.transform.name == "Box(Clone)"))
        {
            if (hitUp.transform.name != "Box(Clone)")
            {
                Destroy(hitUp.transform.gameObject);
            }
            else
            {
                hitUp.transform.GetComponent<Box>().explode();
            }
        }

        if (hitDown.transform != null && (hitDown.transform.tag != "Wall" || hitDown.transform.name == "Box(Clone)"))
        {
            if (hitDown.transform.name != "Box(Clone)")
            {
                Destroy(hitDown.transform.gameObject);
            }
            else
            {
                hitDown.transform.GetComponent<Box>().explode();
            }
        }

        if (hitRight.transform != null && (hitRight.transform.tag != "Wall" || hitRight.transform.name == "Box(Clone)"))
        {
            if (hitRight.transform.name != "Box(Clone)")
            {
                Destroy(hitRight.transform.gameObject);
            }
            else
            {
                hitRight.transform.GetComponent<Box>().explode();
            }
        }

        if (hitLeft.transform != null && (hitLeft.transform.tag != "Wall" || hitLeft.transform.name =="Box(Clone)"))
        {
            if (hitLeft.transform.name != "Box(Clone)")
            {
                Destroy(hitLeft.transform.gameObject);
            }
            else
            {
                hitLeft.transform.GetComponent<Box>().explode();
            }
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.tag = "Wall";
        }
    }
}
