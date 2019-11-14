using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(InteractionBehaviour))]
public class Block : MonoBehaviour
{

    private Rigidbody rb;
    private InteractionBehaviour ib;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ib = GetComponent<InteractionBehaviour>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            anim.SetTrigger("Autoplace");
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
