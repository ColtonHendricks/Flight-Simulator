using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadingIndicator : MonoBehaviour
{
    

    private Vector3 yRotation;
    
    [SerializeField] private Transform headingPlane;

    [SerializeField] private Transform player;

    private void Update(){

        yRotation.z = player.eulerAngles.y;
        headingPlane.eulerAngles = yRotation;
    }
}
