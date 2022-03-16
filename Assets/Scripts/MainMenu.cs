using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayButton(int i)
    {
        ApplicationManager.gameMode = i;
        Initiate.Fade("first", Color.black, 1.5f);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
