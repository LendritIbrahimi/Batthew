using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour {
    private GameObject mainSprite;
	// Use this for initialization
	void Awake () {
        if (transform.parent.name == "MainObject")
        {
            mainSprite = transform.parent.GetComponentInChildren<SpriteRenderer>().gameObject;
            mainSprite.SetActive(false);
        }
    }
}
