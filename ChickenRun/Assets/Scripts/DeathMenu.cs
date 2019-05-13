using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public string gameLevel;

    public void RestartGame()
    {
        Application.LoadLevel(gameLevel);
    }

    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
    }

}
