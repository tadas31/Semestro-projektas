using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    public Rigidbody2D rdbd;
    Rigidbody2D spikes;
    public static bool inZone;

	// Use this for initialization
	void Start () {
        spikes = GetComponent<Rigidbody2D>();
        spikes.constraints = RigidbodyConstraints2D.FreezePositionY;
        inZone = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (inZone)
        {
            spikes.constraints = RigidbodyConstraints2D.None;
        }
        if (Input.GetMouseButtonDown(0) && cameraMovement.moveCamera)
            RemoveSpike();
               
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            gameObject.SetActive(false);
    }

    private void RemoveSpike()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (hit && hit.collider.tag == "FallingSpikes")
        {
            hit.collider.gameObject.SetActive(false);
            TutorialScript.wasFallingSpikesRemoved = true;
        }
    }
}
