using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameMenu : MonoBehaviour
{


    public void inGameMenuButton()
    {

        Initiate.Fade("mainmenu", Color.black, 3.0f);
        Time.timeScale = 1.0f;
    }


}
