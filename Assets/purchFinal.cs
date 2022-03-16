using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purchFinal : MonoBehaviour
{
    public int cost;
    public int id;

    public GameObject can, cannot;

    public void purchase()
    {
        int points = PlayerPrefs.GetInt("points", 0);
        if (points > cost)
        {

            PlayerPrefs.SetInt("points", points - cost);
            PlayerPrefs.SetInt("" + id, 1);
            transform.parent.parent.parent.gameObject.SetActive(false);
        }
        else
        {
            can.SetActive(false);
            cannot.SetActive(true);
        }
    }
}
