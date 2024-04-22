using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCoordinator : MonoBehaviour
{
    [SerializeField] Transform turnCoordPlane;
    [SerializeField] Transform realPlane;

    private Vector3 xRotation;

    // Update is called once per frame
    void Update()
    {
        xRotation.z = -realPlane.eulerAngles.x;
        turnCoordPlane.eulerAngles = xRotation;
    }
}
