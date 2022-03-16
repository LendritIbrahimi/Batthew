using UnityEngine.UI;
using UnityEngine;

public class pointsManager : MonoBehaviour
{
    private int sHighScore;
    private int sPoints;

    public GameObject gPoints, gHighscore;

    void Start()
    {
        PlayerPrefs.SetInt("points", 2000);
        if (gPoints)
        {
            sPoints = PlayerPrefs.GetInt("points", 0);
            gPoints.GetComponent<Text>().text = "Points: " + sPoints;

        }
        if (gHighscore)
        {
            sHighScore = PlayerPrefs.GetInt("highscore", 0);
            gHighscore.GetComponent<Text>().text = "Highscore: " + sHighScore;
        }
    }

    void Update()
    {
        if (sPoints != PlayerPrefs.GetInt("points", 0) && gPoints)
        {
            sPoints = PlayerPrefs.GetInt("points", 0);
            gPoints.GetComponent<Text>().text = "Points: " + sPoints;
        }

        if (sHighScore != PlayerPrefs.GetInt("highscore", 0) && gHighscore)
        {
            sHighScore = PlayerPrefs.GetInt("highscore", 0);
            gHighscore.GetComponent<Text>().text = "Highscore: " + sHighScore;
        }
    }
}
