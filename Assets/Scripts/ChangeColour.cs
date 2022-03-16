using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    private Color lerpedColor;
    public float minVal,speed;
    static float tmax = 0.8f, tmin = 0.2f;
    private int i = 1;
    // Update is called once per frame
    void Start()
    {
        tmax = minVal;
    }
    void Decrease()
    {
        tmin -= speed * Time.deltaTime;
    }
    void Increase()
    {
        tmax += speed * Time.deltaTime;
    }
    void Update()
    {
        switch (i)
        {
            case 0:
                lerpedColor = new Color(tmax, tmin, minVal);
                if (tmax < 0.2f)
                {
                    Increase();
                }
                else
                {
                    tmax = 0.2f;
                    Decrease();
                }
                if (tmin < minVal)
                {
                    tmax = minVal;
                    tmin = 0.2f;
                    i++;
                }
                break;
            case 1:
                lerpedColor = new Color(tmin, tmax, minVal);
                if (tmax < 0.2f)
                {
                    Increase();
                }
                else
                {
                    tmax = 0.2f;
                    Decrease();
                }
                if (tmin < minVal)
                {
                    tmax = minVal;
                    tmin = 0.2f;
                    i++;
                }
                break;
            case 2:
                lerpedColor = new Color(minVal, tmin, tmax);
                if (tmax < 0.2f)
                {
                    Increase();
                }
                else
                {
                    tmax = 0.2f;
                    Decrease();
                }
                if (tmin < minVal)
                {
                    tmax = minVal;
                    tmin = minVal;
                    i = 0;
                }
                break;
        }
        GetComponent<Camera>().backgroundColor = lerpedColor;
    }
}
