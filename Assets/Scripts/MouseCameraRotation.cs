using UnityEngine;

public class MouseCameraRotation : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(InputManager.Instance.MouseVertical, InputManager.Instance.MouseHorizontal,0);
    }
}
