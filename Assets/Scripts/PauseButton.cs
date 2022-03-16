using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject child;
    public GameObject Main;
    public void reActivate(bool setActive)
    {
        child.SetActive(setActive);

        if (setActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        Main.GetComponent<ChangeGravity>().isRunning = !setActive;
    }
}
