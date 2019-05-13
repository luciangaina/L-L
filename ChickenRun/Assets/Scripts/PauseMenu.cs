using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public string gameLevel;

    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
         pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(gameLevel);
    }

    public void QuitToMain()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
    }
}
