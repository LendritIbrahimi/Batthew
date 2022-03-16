using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryTiling : MonoBehaviour
{
    public GameObject mainObject;
    public int distanceModifier = 0;
    public int number = 2;
    public float camOffset = 0.5f;
    public bool isObstacle = false;
    private int tims;
    private float spriteWidth = 0f;     // the width of our element
    private GameObject[] secondObjects;
    void Start()
    {
        tims = number;
        secondObjects = new GameObject[number];
        SpriteRenderer sRenderer = mainObject.GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x + distanceModifier;
        for (int i = 0; i < number; i++)
        {
            secondObjects[i] = Instantiate(mainObject, transform);
            secondObjects[i].transform.localPosition = new Vector2(spriteWidth * i, 0);
        }
    }

    public void CloseApplication(){
        Application.Quit();
    }

    void Update()
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(new Vector2(secondObjects[i].transform.position.x + spriteWidth, 0));

            if (viewPos.x < camOffset)
            {
                secondObjects[i].transform.localPosition = new Vector2(spriteWidth * tims, 0);
                tims++;
                if (isObstacle)
                {
                    secondObjects[i].GetComponent<ObstaclesSpawner>().ChangePos();
                }
            }

        }
    }

}
