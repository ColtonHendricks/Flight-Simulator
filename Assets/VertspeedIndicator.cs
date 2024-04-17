using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertspeedIndicator : MonoBehaviour
{
    private const float minVertSpeedAngle = 134f;
    private const float maxVertSpeedAngle = 314f;

    [SerializeField]
    private Transform needleTransform;

    [SerializeField] float vertspeed;

    [SerializeField] Rigidbody rb;

    private float vertspeedMax;
    private float vertspeedMin;

    private float velocity;
    private float position;
    private float lastPosition;
    private float lastVelocity;

    private void Awake() {

        vertspeedMax = 20000f;
        vertspeedMin = -20000f;

        velocity = 0f;
        position = 0f;
        lastPosition = 0f;
        lastVelocity = 0f;
    }

    private void Update(){
        
        position = rb.position.y * 3.28f;
        velocity = (position - lastPosition) / (Time.fixedDeltaTime);
        lastPosition = rb.position.y * 3.28f;

        // I dont know why vertspeed has to be negative here but it is reversed if it is not
        vertspeed = -(velocity - lastVelocity) / (Time.fixedDeltaTime);
        lastVelocity = (position - lastPosition) / (Time.fixedDeltaTime);
        
        if(vertspeed > vertspeedMax) vertspeed = vertspeedMax;
        if(vertspeed < vertspeedMin) vertspeed = vertspeedMin;

        if(vertspeed != 0)needleTransform.eulerAngles = new Vector3(0,0, GetSpeedRotation());
    }

    private float GetSpeedRotation(){
        float totalAngleSize = minVertSpeedAngle - maxVertSpeedAngle;

        float vertspeedNormalized = vertspeed / vertspeedMax;

        return minVertSpeedAngle - vertspeedNormalized * totalAngleSize;
    }
}
