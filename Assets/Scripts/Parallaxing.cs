using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour
{

    public float smoothing = 1f;            // How smooth the parallax is going to be. Make sure to set this above 0
    public float size = 1;
    private Transform cam;                  // reference to the main cameras transform
    private Vector3 previousCamPos;         // the position of the camera in the previous frame

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position - (Vector3.right * (size / (Mathf.Abs(transform.position.z) + 1)));
        transform.position = Vector3.Lerp(transform.position, pos, smoothing * Time.deltaTime);
    }
}