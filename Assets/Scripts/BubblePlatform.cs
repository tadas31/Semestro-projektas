using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlatform : MonoBehaviour {

    public Animator animator;

    public static bool isPoped;
    public static bool active = true;

    public Rigidbody2D rdbd;

    public float height;
    GameObject[] BubblePlatforms;

    // Use this for initialization
    void Start () {
        BubblePlatforms = GameObject.FindGameObjectsWithTag("BubblePlatform");
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("Pop", isPoped);
        GetComponent<Collider2D>().enabled = active;
        Debug.Log(isPoped);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rdbd.velocity += new Vector2(0, -rdbd.velocity.y);
            rdbd.AddForce(new Vector2(0, height));
            isPoped = true;
            Debug.Log(isPoped);
            active = false;           
        }
    }


}
