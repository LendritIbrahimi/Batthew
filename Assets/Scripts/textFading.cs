using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class textFading : MonoBehaviour
{
    public float speed = 10;
    public bool isText = true;
    void FixedUpdate()
    {
        if (isText)
        {
            GetComponent<Text>().color = new Color(GetComponent<Text>().color.r, GetComponent<Text>().color.g, GetComponent<Text>().color.b, Mathf.PingPong(Time.time * (speed / 10), 1));
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, Mathf.PingPong(Time.time * (speed / 10), 1));
        }
    }
}
