using UnityEngine;

public class GyroManager : MonoBehaviour
{
   bool gyroEnabled;
   Gyroscope gyro;

    void Start(){
        gyroEnabled = EnableGyro();
    }

    bool EnableGyro(){
        if(SystemInfo.supportsGyroscope){
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }
    
    void Update(){
        if(gyroEnabled)
            transform.localRotation = GyroToUnity(gyro.attitude);
    }

    Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}