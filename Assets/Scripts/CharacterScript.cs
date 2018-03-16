using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour {

    private bool groundIsTouching;// Tells if the character is touching the ground
    private Rigidbody2D rdbd;
    public float hight;
    public float speed;
    public float forceMultiplier;

    private Text candyCount;
    private int counter = 0;

    // STATS
    public int lives;


    // Use this for initialization
    void Start () {
        rdbd = GetComponent<Rigidbody2D>();
        candyCount = GameObject.Find("CandyCount").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    //private void Jump()
    //{
    //    rdbd.velocity += new Vector2(0, hight);
    //}

    //private void MoveRight()
    //{
    //    rdbd.velocity += new Vector2(speed, 0);
    //}

    //private void MoveLeft()
    //{
    //    rdbd.velocity += new Vector2(-speed, 0);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundIsTouching = true;
        }
        
        if(collision.gameObject.tag == "Damage1")
        {
            lives--;
            Vector2 knockbackVelocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * forceMultiplier,
                (transform.position.y - collision.gameObject.transform.position.y) * forceMultiplier);
            Debug.Log(knockbackVelocity);
            rdbd.velocity = -knockbackVelocity;

            if (lives == 0) //When lives = 0, die (restart level for now)
                Die();

            Debug.Log(lives);
        }
        if (collision.gameObject.tag == "Damage_fatal")
            Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            collision.gameObject.active = false;
            counter++;
            candyCount.text = counter.ToString();
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundIsTouching = false;
        }

    }

    //private void FixedUpdate()
    //{
    //    if (groundIsTouching && Input.GetMouseButton(0))
    //    {
    //        if (Input.mousePosition.y > (Screen.height * 3 / 4))
    //        {
    //            Jump();
    //        }
    //        else {
    //            if (Input.mousePosition.x >(Screen.height /2))
    //            {
    //                MoveRight();
    //            }
    //            if (Input.mousePosition.x < (Screen.height / 2))
    //            {
    //                MoveLeft();
    //            }
    //        }
    //    }
    //}

    void Die()
    {
        // Restart
        Application.LoadLevel(Application.loadedLevel);
    }
}
