using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{

    public string mainMenu;

    public void Back()
    {
        Application.LoadLevel(mainMenu);
    }
}
