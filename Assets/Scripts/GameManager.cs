using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    int score;
    [SerializeField] TextMeshProUGUI endGameScore;
    [SerializeField] GameObject gameOverCanvas;

    void Start()
    {
        HideCursor();
    }

    void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void GameOver()
    {
        ShowCursor();
        gameOverCanvas.SetActive(true);
        endGameScore.SetText(score.ToString());

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Environment");
    }
}
