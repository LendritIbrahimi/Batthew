using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class changeBrightness : MonoBehaviour
{
    private Color tmp = Color.white;

    public void brightnessAlpha(float a)
    {
        tmp.a = a;
        GetComponent<Image>().color = tmp;
        ApplicationManager.ending = a;
    }
    private void Start()
    {
        tmp.a = ApplicationManager.ending;
        GetComponent<Image>().color = tmp;

    }
}