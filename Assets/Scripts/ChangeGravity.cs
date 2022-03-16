using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject pointSound;
    private bool gStart = false;
    public bool isRunning = false, increaseSpeed;
    private Rigidbody2D mainrb;

    void Start()
    {
        mainrb = GetComponent<Rigidbody2D>();
        mainrb.simulated = false;

        switch (ApplicationManager.gameMode)
        {
            case 0:
                m_Speed /= 1.5f;
                mainrb.gravityScale /= 2;
                break;
            case 2:
                m_Speed *= 2;
                mainrb.gravityScale *= 1.5f;
                break;
        }

    }

    public void setRunning()
    {
        isRunning = true;
        gStart = true;
    }

    void Update()
    {
        if (isRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gStart)
                {
                    mainrb.gravityScale *= -1;
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 1);
                    mainrb.AddForce(Vector2.up * GetComponent<Rigidbody2D>().gravityScale * -10);
                    mainrb.velocity = Vector2.zero;
                }
                gStart = true;
            }

            if (gStart)
            {
                if (increaseSpeed)
                {
                    m_Speed += Time.deltaTime / 25;
                }
                canvas.SetActive(false);
                mainrb.simulated = true;
                transform.Translate(Vector2.right * m_Speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject sound = Instantiate(pointSound, null);
        Destroy(sound, 4f);
        mainrb.gravityScale = Mathf.Abs(mainrb.gravityScale);
        isRunning = false;
        GameObject.Find("GameIsOver").GetComponent<EndGameRestart>().endGame(0.45f);
        GameObject.Find("GameIsOver").GetComponent<CameraShake>().Shake(0.075f, 0.1f);
        mainrb.angularVelocity = 250;
        mainrb.AddForce(Vector2.left * m_Speed * 50);
    }

}
