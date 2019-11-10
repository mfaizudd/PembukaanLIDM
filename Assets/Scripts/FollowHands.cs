using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHands : MonoBehaviour
{
    [SerializeField] RiggedHand leftHand, rightHand;
    [SerializeField] Transform controller;

    [SerializeField]
    [Range(0, 1)] float distanceOffset = .2f;
    [Range(0, 1)] float controllerDistanceOffset = .2f;

    [SerializeField] float defaultZ;

    [Header("Camera")]
    public bool enableCameraFollow = true;
    [SerializeField] float cameraSpeeed = 1;

    [Header("Controller")]
    public bool enableControllerFollow = true;
    [SerializeField] float controllerSpeed = 1;

    private void Update()
    {
        var leftZRaw = leftHand?.GetLeapHand()?.PalmPosition.z;
        var rightZRaw = rightHand?.GetLeapHand()?.PalmPosition.z;

        var leftZ = leftZRaw ?? rightZRaw ?? 0;
        var rightZ = rightZRaw ?? leftZRaw ?? 0;

        var middle = Mathf.Abs((Mathf.Abs(leftZ) - Mathf.Abs(rightZ))) / 2;
        var middleDistance = Mathf.Min(leftZ, rightZ) + middle;
        var distance = Mathf.Abs(controller.position.z - middleDistance);

        if(distance > 0.2f && enableControllerFollow)
        {
            controller.position = Vector3.MoveTowards(controller.position, new Vector3(controller.position.x, controller.position.y, middleDistance), controllerSpeed * Time.deltaTime);
        }
        
        if(enableCameraFollow)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, middleDistance - distanceOffset), cameraSpeeed * Time.deltaTime);
    }
}
