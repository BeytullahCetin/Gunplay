using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }


    float horizontal;
    float vertical;
    public Quaternion gyro;

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

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
            Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        /* horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y"); */
        if(SystemInfo.supportsGyroscope)
            gyro = GyroToUnity(Input.gyro.attitude);

    }

    Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
