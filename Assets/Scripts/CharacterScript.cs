using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{

    private bool groundIsTouching;// Tells if the character is touching the ground
    private bool isFalling;//Tells if the character is falling
    private bool canClimb;
    private Rigidbody2D rdbd;
    public float hight;
    public float speed;
    public float forceMultiplier;
    public float trampolineJumpHeight;
    public float speedOfClimb;

    private Text candyCount;
    private int counter = 0;

    // STATS
    public int lives;


    // Use this for initialization
    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
        candyCount = GameObject.Find("CandyCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfFalling();
    }
    private void CheckIfFalling()
    {
        if (rdbd.velocity.y < -0.1)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
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

    private void ClimbUp()
    {
        rdbd.velocity = Vector2.zero;
        rdbd.transform.Translate(Vector2.up * Time.deltaTime * speedOfClimb);
    }
    private void ClimbDown()
    {
        rdbd.velocity = Vector2.zero;
        rdbd.transform.Translate(Vector2.down * Time.deltaTime * speedOfClimb);
    }

    private void MoveRightByTranslate()
    {
        rdbd.transform.Translate(Vector2.right * Time.deltaTime * speedOfClimb);
    }

    private void MoveLeftByTranslate()
    {
        rdbd.transform.Translate(Vector2.left * Time.deltaTime * speedOfClimb);
    }


    private void TrampolineBounce()
    {
        rdbd.velocity += new Vector2(0, -rdbd.velocity.y);
        rdbd.velocity += Vector2.up * trampolineJumpHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline" && isFalling)
        {
            TrampolineBounce();
        }

        if (collision.gameObject.tag == "Damage1")
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        transform.parent = collision.transform;

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "FadingGround" || collision.gameObject.tag == "Trampoline")
        {
            groundIsTouching = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            collision.gameObject.active = false;
            counter++;
            candyCount.text = counter.ToString();
        }

        if (collision.gameObject.tag == "Ladder")
        {
            canClimb = true;
            collision.gameObject.GetComponent<LadderScript>().CanGoThrow();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            canClimb = false;
            collision.gameObject.GetComponent<LadderScript>().CannotGoThrow();
            rdbd.gravityScale = 1;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "FadingGround" || collision.gameObject.tag == "Trampoline")
        {
            groundIsTouching = false;
            transform.parent = null;
        }

        

    }

    private void MovementOnTheGround()
    //{
        if (Input.GetMouseButton(0) && groundIsTouching)
    //    {
    //        if (Input.mousePosition.y > (Screen.height * 3 / 4))
    //        {
    //            Jump();
    //        }
            else
            {
                if (Input.mousePosition.x > (Screen.height / 2))
    //                MoveRight();
    //            }
    //            if (Input.mousePosition.x < (Screen.height / 2))
    //            {
    //                MoveLeft();
    //            }
    //        }
    //    }
    //}
    }

    private void MovementOnTheLadded()
    {
        if (Input.GetMouseButton(0))
        {
            rdbd.gravityScale = 0;

            if (Input.mousePosition.y > (Screen.height * 3 / 4))
            {

                ClimbUp();
            }
            else
            if (Input.mousePosition.y < (Screen.height * 1 / 4))
            {
                ClimbDown();
            }
            else
            {
                if (Input.mousePosition.x > (Screen.width / 2))
                {
                    MoveRightByTranslate();
                }
                if (Input.mousePosition.x < (Screen.width / 2))
                {
                    MoveLeftByTranslate();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (canClimb)
        {
            MovementOnTheLadded();
        }
        else
            MovementOnTheGround();
    }

    void Die()
    {
        // Restart
        Application.LoadLevel(Application.loadedLevel);
    }
}
