using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltimeterController : MonoBehaviour
{
    private const float minAltAngle = 44.5f;
    private const float maxAltAngle = -310f;

    [SerializeField]
    private Transform needleTransform;

    [SerializeField] float altitude;

    [SerializeField] Rigidbody rb;

    private float altMax;

    private void Awake() {

        altMax = 9900f;
    }

    private void Update(){
        altitude = rb.position.y * 3.28f;
        if(altitude > altMax) altitude = altMax;

        if(altitude>0) needleTransform.eulerAngles = new Vector3(0,0, GetSpeedRotation());
    }

    private float GetSpeedRotation(){
        float totalAngleSize = minAltAngle - maxAltAngle;

        float altNormalized = altitude / altMax;

        return minAltAngle - altNormalized * totalAngleSize;
    }
}
