using UnityEngine;
using UnityEngine.UI;
public class ApplicationManager : MonoBehaviour
{
    static public float ending = 0;
    static public int effectNumber = 1, characterNumber = 1;
    public int number;
    static public GameObject[] text, effect, allEffects;
    static public int interval;
    static public int gameMode = 1;

    public void Start()
    {
        int effectID = PlayerPrefs.GetInt("effectNumber", 0);
        if (effectID != 0)
        {
            text[effectID - 1].SetActive(false);
            effect[effectID - 1].SetActive(true);
        }

        int characterID = PlayerPrefs.GetInt("characterNumber", 80);
        if (characterID != 81)
        {
            print(characterID);
            text[characterID - 1].SetActive(false);
            effect[characterID - 1].SetActive(true);
        }
    }

    public void onClickEffect()
    {
        if (number >= interval)
        {
            characterNumber = number + 1;
            PlayerPrefs.SetInt("characterNumber", characterNumber);
        }
        else
        {
            effectNumber = number + 1;
            PlayerPrefs.SetInt("effectNumber", effectNumber);
        }
    }
    public void onClickText(int fs)
    {
        int startPoint = 0, endPoint = interval;
        if (number >= interval)
        {
            startPoint = interval;
            endPoint = text.Length;
        }
        for (int i = startPoint; i < endPoint; i++)
        {
            if (number != i)
            {
                text[i].SetActive(true);
                effect[i].SetActive(false);

            }
            else
            {
                text[i].SetActive(false);
                effect[i].SetActive(true);

            }
        }
    }

}
