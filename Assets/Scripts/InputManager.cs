using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public static InputManager Instance { get; private set; }
    [SerializeField] float _mouseHorizontal;
    [SerializeField] float _mouseVertical;
    public float MouseHorizontal { get { return _mouseHorizontal; } }
    public float MouseVertical { get { return _mouseVertical; } }
    public bool ShootButton { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        MouseSlideInput();
        ShootButtonInput();
    }
    void MouseSlideInput()
    {
        _mouseHorizontal = Input.GetAxis("Mouse X");
        _mouseVertical = -Input.GetAxis("Mouse Y");
    }

    void ShootButtonInput()
    {
        ShootButton = Input.GetButton("Fire1");
    }

}
