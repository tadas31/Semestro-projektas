using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatformScript : MonoBehaviour {

    GameObject[] fadingPlatform;
    float disapear;

    // Use this for initialization
    void Start () {
        fadingPlatform = GameObject.FindGameObjectsWithTag("FadingGround");
        disapear = 3.0f;
    }
	
	// Update is called once per frame
	void Update () {
        disapear -= Time.deltaTime;

        if (disapear <= 0.0f)
        {
            StartCoroutine(ShowAndHide());
            disapear = 3.0f;
        }
    }


    IEnumerator ShowAndHide()
    {
        foreach (var platform in fadingPlatform)
            platform.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2.05f);
        foreach (var platform in fadingPlatform)
            platform.GetComponent<Collider2D>().enabled = true;
        disapear = 4.0f;
    }
}
