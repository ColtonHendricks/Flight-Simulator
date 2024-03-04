using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject  MainCamera;
    public GameObject ExternalCamera;

    // Update is called once per frame
    void Update(){
           if(Input.GetKeyDown(KeyCode.V))
           {
           MainCamera.SetActive(true);
           ExternalCamera.SetActive(false);
           }
           
           if(Input.GetKeyDown(KeyCode.B))
           {
           MainCamera.SetActive(false);
           ExternalCamera.SetActive(true);
           }
    }
}
