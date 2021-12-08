using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   private bool gyroEnabled;
   private Gyroscope gyro;
   private GameObject cameraContainer;
   private Quaternion rot;

    private void Start(){
        Debug.Log("Start");
        
        cameraContainer = new GameObject("Camera container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro(){
        if(SystemInfo.supportsGyroscope){
            gyro = Input.gyro;
            gyro.enabled = true;
            cameraContainer.transform.rotation = Quaternion.Euler(90f,180f,0);
            rot = new Quaternion(0,0,1,0);

            return true;
        }
        return false;
    }
    
    private void Update(){
        if(gyroEnabled){
            transform.localRotation = gyro.attitude * rot;
        }
    }
}