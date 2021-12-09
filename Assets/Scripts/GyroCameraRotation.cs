using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCameraRotation : MonoBehaviour
{
    void Update()
    {
        GyroManager.Instance.getMainCamera.transform.localRotation = GyroManager.Instance.getCurrentRotation;
    }
}
