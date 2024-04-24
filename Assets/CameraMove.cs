using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform[] povs;
    [SerializeField] float speed;

    private int index = 0;
    private Vector3 target;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V) && index == 0){ 
            index = 1;
        }
        else if(Input.GetKeyDown(KeyCode.V) && index == 1) index = 0;

        target = povs[index].position;      
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.forward = povs[index].forward;

    }
} 