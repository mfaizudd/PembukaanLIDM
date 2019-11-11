using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{

    public Transform originPosition = null;
    [SerializeField] float totalWaitTime = 3;

    float waitTime;

    private void Start()
    {
        waitTime = totalWaitTime;
    }

    private void OnTriggerStay(Collider other)
    {
        Block block = other.GetComponent<Block>();
        if (block != null)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                waitTime = totalWaitTime;
                block.transform.position = originPosition.position;
                block.transform.rotation = originPosition.rotation;
            }
        }
        else
            waitTime = totalWaitTime;
    }
}
