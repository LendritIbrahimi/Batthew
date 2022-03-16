using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class controllDisplay : MonoBehaviour {
    public GameObject StartButtons, StartText, StartImage;

    void Start()
    {
        if (PlayerPrefs.GetInt("shown", 0) == 0)
        {
            StartButtons.SetActive(true);
    
        }
        else
        {
            StartButtons.SetActive(false);
            StartImage.GetComponent<Image>().color = Color.clear;
            StartImage.GetComponent<Image>().raycastTarget = true;
            StartText.GetComponent<Text>().text = "TAP  TO  START";
        }
    }
    public void setControlls(int i)
    {
        PlayerPrefs.SetInt("shown", i);
    }
}
