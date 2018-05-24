using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatformScript : MonoBehaviour {

    GameObject[] fadingPlatform;

    public void Appear()
    {
        fadingPlatform = GameObject.FindGameObjectsWithTag("FadingGround");
        foreach (var platform in fadingPlatform)
            platform.GetComponent<Collider2D>().enabled = true;
    }

    public void Disappear()
    {
        fadingPlatform = GameObject.FindGameObjectsWithTag("FadingGround");
        foreach (var platform in fadingPlatform)
            platform.GetComponent<Collider2D>().enabled = false;
    }
}
