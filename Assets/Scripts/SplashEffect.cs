using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
    public GameObject Splash;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            GameObject spl = Instantiate(Splash, null);
            if (other.transform.position.y > 0)
            {
                spl.transform.localScale = new Vector3(1, -1, 1);
            }
            spl.transform.position = other.transform.position;
            Destroy(spl, 0.45f);
            GameObject.Find("GameIsOver").GetComponent<EndGameRestart>().endGame(0.45f);
        }
    }
}
