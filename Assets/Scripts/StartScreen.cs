using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class StartAndRestartMenu : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI instructionText;

    private bool isGameStarted = false;
    private bool isGameOver = false;

    void Start()
    {
        // Freeze game at start
        Time.timeScale = 0f;
        ShowStartMenu();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!isGameStarted && !isGameOver)
            {
                StartGame();
            }
            else if (isGameOver)
            {
                RestartGame();
            }
        }
    }

    public void ShowStartMenu()
    {
        titleText.text = "Flappy Bird";
        instructionText.text = "Click or Space to Start";
        gameObject.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        isGameOver = true;
        titleText.text = "Game Over";
        instructionText.text = "Click or Space to Restart";
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void StartGame()
    {
        isGameStarted = true;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
