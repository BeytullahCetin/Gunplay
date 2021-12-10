using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCameraRotation : MonoBehaviour
{
    void Update()
    {
        transform.localRotation = GyroManager.Instance.CurrentRotation;
    }
}
