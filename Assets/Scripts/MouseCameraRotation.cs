using UnityEngine;

public class MouseCameraRotation : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (!player.IsDead)
            transform.eulerAngles += new Vector3(InputManager.Instance.MouseVertical, InputManager.Instance.MouseHorizontal, 0);
    }
}
