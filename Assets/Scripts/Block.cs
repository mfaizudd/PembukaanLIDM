using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(InteractionBehaviour))]
public class Block : MonoBehaviour
{

    private Rigidbody rb;
    private InteractionBehaviour ib;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ib = GetComponent<InteractionBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var holder = other.GetComponent<Holder>();

        if (holder == null) return;
        ib.enabled = false;
        rb.isKinematic = true;
        holder.Attach(transform);
    }
}
