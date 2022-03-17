using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{

    private int totalScore = 0;
    string playerName = "";
    public int size;
    private int check = 0;
    public GameObject Container;
    public GameObject Input;
    public GameObject Canvas;
    private GameObject[] containersMain;
    List<dreamloLeaderBoard.Score> scoreList;
    // Reference to the dreamloLeaderboard prefab in the scene

    public dreamloLeaderBoard dl;


    private bool once = true;
    void Start()
    {

        totalScore = PlayerPrefs.GetInt("highscore", 0);
        // get the reference here...
        this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();


        containersMain = new GameObject[size];
        for (int i = 0; i < size; i++)
        {

            containersMain[i] = Instantiate(Container, Canvas.transform);
            containersMain[i].transform.position -= Vector3.up * 45 * i;
        }
        scoreList = dl.ToListHighToLow();

        generateScore();
        if (scoreList.Count == 0)
        {
            containersMain[4].transform.GetChild(1).gameObject.GetComponent<Text>().text = "Loading";
        }
    }

    void Update()
    {
        if (once)
        {
            if (scoreList.Count != check && once)
            {
                generateScore();
                once = false;
                check = scoreList.Count;
            }
            else
            {
                scoreList = dl.ToListHighToLow();
            }
        }
    }


    public void generateScore()
    {
        scoreList = dl.ToListHighToLow();
        for (int i = 0; i < size; i++)
        {
            if (i < scoreList.Count)
            {
                containersMain[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = scoreList[i].playerName;
                containersMain[i].transform.GetChild(1).gameObject.GetComponent<Text>().text = scoreList[i].score.ToString();
                containersMain[i].transform.GetChild(2).gameObject.GetComponent<Text>().text = scoreList[i].dateString;
            }
            else
            {
                containersMain[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
                containersMain[i].transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
                containersMain[i].transform.GetChild(2).gameObject.GetComponent<Text>().text = "";
            }
        }
    }

    public void printScore()
    {
        playerName =  Input.GetComponent<InputField>().text;
        playerName = playerName.ToUpper(); 
        if (playerName != "")
        {
            dl.AddScore(playerName, totalScore);
            this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
            once = true;
        }
    }
}
