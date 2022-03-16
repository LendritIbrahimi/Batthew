using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EffectCreator : MonoBehaviour
{
    public GameObject mainOB, cost, isd;


    public GameObject[] effectObjects, texts, effects;
    public Vector2 size;
    public int distance, interval;

    void Start()
    {
        texts = new GameObject[effectObjects.Length];
        effects = new GameObject[effectObjects.Length];
        int movCoef = 0;
        for (int i = 0; i < effectObjects.Length; i++)
        {
            GameObject gb = Instantiate(mainOB, transform);
            float modDis = size.y;

            if (i % interval == 0 && i != 0)
            {
                size.y += distance;
                movCoef = 0;
            }


            gb.transform.localPosition = new Vector2(-size.x + movCoef * distance, -size.y);

            gb.GetComponentInChildren<Text>().text = "" + (i + 1);
            gb.name = gb.name + "-" + i;
            gb.GetComponent<ApplicationManager>().number = i;
            texts[i] = gb.GetComponentInChildren<Text>().gameObject;
            effects[i] = gb.transform.Find("effectGameObject").gameObject;

            gb.GetComponent<EffectID>().ids = isd;
            gb.GetComponent<EffectID>().cost = cost;

            Vector2 ab = Camera.main.ScreenToWorldPoint(gb.transform.position);

            GameObject bg = Instantiate(effectObjects[i], gb.transform.Find("effectGameObject").transform);

            bg.transform.position = ab;
            bg.transform.localScale /= 2f;
            movCoef++;
        }
        ApplicationManager.interval = interval;
        ApplicationManager.effect = effects;
        ApplicationManager.text = texts;
        ApplicationManager.allEffects = effectObjects;

    }
}
