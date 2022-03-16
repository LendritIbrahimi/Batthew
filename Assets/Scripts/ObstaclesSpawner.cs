using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public float maxDistace, minDistance;

    // Update is called once per frame
    void Start()
    {
        ChangePos();
    }

    public void ChangePos()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(minDistance, maxDistace), transform.position.z);
    }

}
