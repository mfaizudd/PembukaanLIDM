using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimationEvent : MonoBehaviour
{
    public Transform origin;
    public Holder holder;

    public void OnAutoplaceStart()
    {
        transform.position = origin.position;
        transform.rotation = origin.rotation;
    }

    public void OnAutoplaceEnd()
    {
        holder.Attach(transform);
    }
}
