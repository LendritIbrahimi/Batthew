using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int highscore;
    public Color col;
    Text text;
    public GameObject secondText;


    void Awake()
    {
        if (GetComponent<Text>())
        {
            text = GetComponent<Text>();
        }
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        secondText.GetComponent<Text>().text = "" + highscore;
        score = 0;

    }


    void Update()
    {
        if (score > highscore && ApplicationManager.gameMode == 2)
        {
            highscore = score;
            secondText.GetComponent<Text>().text = "" + highscore;
            secondText.GetComponent<Text>().color = col;
        }
        PlayerPrefs.SetInt("highscore", highscore);
        // Set the displayed text to be the word "Score" followed by the score value.
        if (text = GetComponent<Text>())
        {
            text.text = "" + score;
        }
    }
}