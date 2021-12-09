using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
   public static GyroManager Instance { get; private set; }
   private bool gyroEnabled;
   private Gyroscope gyro;
   private GameObject player;
   private GameObject mainCamera;
   private Quaternion currentRotation;
   private Quaternion rot;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start(){
        Debug.Log("Start");
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro(){
        if(SystemInfo.supportsGyroscope){
            gyro = Input.gyro;
            gyro.enabled = true;
            player.transform.rotation = Quaternion.Euler(90f,180f,0);
            rot = new Quaternion(0,0,1,0);

            return true;
        }
        return false;
    }
    
    private void Update(){
        Debug.Log(gyro.attitude * rot);
        if(gyroEnabled){
            currentRotation = gyro.attitude * rot;
        }
    }

    public GameObject getMainCamera{get{return mainCamera;}}

    public Quaternion getCurrentRotation{get{return currentRotation;}}
}