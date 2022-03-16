using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndGameRestart : MonoBehaviour
{
    [SerializeField]
    private GameObject mainObject;

    [SerializeField]
    private GameObject score;

    private void Awake()
    {
        Time.timeScale = 1;

    }
    public void endGame(float time)
    {
        StartCoroutine(tem(time / 2));
    }
    IEnumerator tem(float t)
    {
        mainObject.GetComponent<ChangeGravity>().isRunning = false;

        yield return new WaitForSeconds(t);


        int sscore = 0;

        int.TryParse(score.GetComponent<Text>().text, out sscore);
        PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points", 0) + sscore * (ApplicationManager.gameMode + 1));
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 3f);


    }
}
