using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    private bool groundIsTouching;// Tells if the character is touching the ground
    private Rigidbody2D rdbd;
    public float hight;
    public float speed;
	// Use this for initialization
	void Start () {
        rdbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void Jump()
    {
        rdbd.velocity += new Vector2(0, hight);
    }

    private void MoveRight()
    {
        rdbd.velocity += new Vector2(speed, 0);
    }

    private void MoveLeft()
    {
        rdbd.velocity += new Vector2(-speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundIsTouching = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            GameObject candy = GameObject.FindGameObjectWithTag("Candy");
            candy.active = false;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        groundIsTouching = false;
    }

    private void FixedUpdate()
    {
        if (groundIsTouching && Input.GetMouseButton(0))
        {
            if (Input.mousePosition.y > (Screen.height * 3 / 4))
            {
                Jump();
            }
            else {
                if (Input.mousePosition.x >(Screen.height /2))
                {
                    MoveRight();
                }
                if (Input.mousePosition.x < (Screen.height / 2))
                {
                    MoveLeft();
                }
            }
        }
    }
}
