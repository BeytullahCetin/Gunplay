using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]  GameObject canvas;
    [SerializeField]  GameObject canvasCamera;
    
    public void StartGame(){
        canvas.SetActive(false);
        canvasCamera.SetActive(false);
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }
}
