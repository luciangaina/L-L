using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text hiScoreText;
    private float score;
    public string playGameLevel;
    public string tutorialLevel;

    void Start ()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetFloat("HighScore");
        }

        hiScoreText.text = "High Score: " + Mathf.Round(score) + " !!!";
    }
    
    public void PlayGame()
    {
        Application.LoadLevel(playGameLevel);
    }

    public void HowToPlay()
    {
        Application.LoadLevel(tutorialLevel);
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
}
