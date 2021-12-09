using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public float MouseHorizontal { get; private set; }
    public float MouseVertical { get; private set; }
    public float ShootButton{ get; private set;}

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

    void Update()
    {
        MouseSlideInput();
        ShootButtonInput();
    }

    void MouseSlideInput()
    {
        MouseHorizontal = Input.GetAxis("Mouse X");
        MouseVertical = -Input.GetAxis("Mouse Y");
    }

    void ShootButtonInput()
    {
        ShootButton = Input.GetAxis("Fire1");
    }

}
