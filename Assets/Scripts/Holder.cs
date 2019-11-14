using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Holder : MonoBehaviour
{
    [SerializeField] VideoPlayer player;
    [SerializeField] float delayTime = 3;
    [SerializeField] GameObject hands;

    public void Attach(Transform block)
    {
        block.position = transform.position;
        block.rotation = transform.rotation;
        hands.SetActive(false);
        StartCoroutine(StartVideoOn(delayTime));
    }

    IEnumerator StartVideoOn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.Play();
    }
}
