using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentController : MonoBehaviour
{
    private const float minSpeedAngle = 14;
    private const float maxSpeedAngle = -130;

    [SerializeField]
    private Transform needleTransform;

    [SerializeField] float speed;

    [SerializeField] Rigidbody rb;

    private float speedMax;

    private void Awake() {

        speedMax = 104f-40f;
    }

    private void Update(){
        speed = (rb.velocity.magnitude * 1.9f)-40f;
        if(speed > speedMax) speed = speedMax;

        if(speed>0) needleTransform.eulerAngles = new Vector3(0,0, GetSpeedRotation());
    }

    private float GetSpeedRotation(){
        float totalAngleSize = minSpeedAngle - maxSpeedAngle;

        float speedNormalized = speed / speedMax;

        return minSpeedAngle - speedNormalized * totalAngleSize;
    }

}
