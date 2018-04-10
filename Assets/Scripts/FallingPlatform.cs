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
        Debug.Log(LevelScript.canMove);
        if (Input.GetMouseButtonDown(0) && cameraMovement.moveCamera)
            RemoveSpike();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
            gameObject.active = false;
    }

    private void RemoveSpike()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (hit && hit.collider.name == "Falling_spikes")
            hit.collider.gameObject.SetActive(false);       
    }
}
