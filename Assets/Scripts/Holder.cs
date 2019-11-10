using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Holder : MonoBehaviour
{
    [SerializeField] VideoPlayer player;
    [SerializeField] float delayTime = 3;

    public void Attach(Transform block)
    {
        block.position = transform.position;
        block.rotation = transform.rotation;
        StartCoroutine(StartVideoOn(delayTime));
    }

    IEnumerator StartVideoOn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.Play();
    }
}
