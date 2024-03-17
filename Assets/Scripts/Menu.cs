using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    Button resumeGameBtn;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameOverScene");    
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGameHUDScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        Debug.Log("Game resumed!");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void PauseGame()
    {
        Debug.Log("Game paused!");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
