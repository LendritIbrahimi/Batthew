using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour
{

    public float offsetX = 2;
    [Range(0, 2)]
    public float deleteSize;// the offset so that we don't get any weird errors

    // these are used for checking if we need to instantiate stuff
    public bool hasARightBuddy = false;

    public bool reverseScale = false;   // used if the object is not tilable

    private float spriteWidth = 0f;     // the width of our element
    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x + offsetX;
    }

    // Update is called once per frame
    void Update()
    {
        // does it still need buddies? If not do nothing
        if (hasARightBuddy == false)
        {
            // calculate the cameras extend (half the width) of what the camera can see in world coordinates
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;


            // checking if we can see the edge of the element and then calling MakeNewBuddy if we can
            if (cam.transform.position.x >= edgeVisiblePositionRight && hasARightBuddy == false)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
        }
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x <= -deleteSize)
        {
            Destroy(gameObject);
        }
    }

    // a function that creates a buddy on the side required
    void MakeNewBuddy(int rightOrLeft)
    {
        // calculating the new position for our new buddy
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
        // instantating our new body and storing him in a variable
        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;
        newBuddy.name = myTransform.name;
        // if not tilable let's reverse the x size og our object to get rid of ugly seams
        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;
        if (rightOrLeft < 0)
        {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }
}
