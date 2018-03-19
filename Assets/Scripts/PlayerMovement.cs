using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private Button jump;

    private Rigidbody2D rdbd;

    public float moveSpeed;
    public float moveSpeedJ;
    public float jumpHeight;
    public JoystickMovement jsMovement;
    private bool groundIsTouching;
    private bool canClimb;

    public bool kj;

    private Vector3 dir;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    private bool isFalling;
    public float trampolineJumpHeight;
    // Use this for initialization
    void Start () {
        rdbd = GetComponent<Rigidbody2D>();
        jump = GameObject.Find("Jump").GetComponent<Button>();
    }



    // Update is called once per frame
    void Update () {


        if (isGrounded() && Input.GetKeyDown(KeyCode.Space)) // Keyboard
        {
            Debug.Log("Space");
            Jump();
        }
        jump.onClick.RemoveAllListeners();
        if (isGrounded())                                    // Button
        {
            jump.onClick.AddListener(Jump);
        }

        CheckIfFalling();

    }

    void Jump()
    {
       // Debug.Log(isGrounded());
        rdbd.AddForce(new Vector2(0, jumpHeight));
        
    }

    bool isGrounded()
    {
        return grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    private void FixedUpdate()
    {
        
        dir = jsMovement.InputDirection;
        
        if (isGrounded())
        {
            // Joystick movement
            
            rdbd.velocity += new Vector2(dir.x / moveSpeedJ, 0);
            // Debug.Log(rdbd.velocity);

            //if (kj == true)
            //{
            //    // Keyboard movement
            //    float h = Input.GetAxis("Horizontal");
            //    float v = Input.GetAxis("Vertical");
            //    rdbd.velocity = new Vector2(h * moveSpeed, rdbd.velocity.y);
            //}
        }
        if (dir.y > 0 && canClimb)
        {
            MovementOnTheLadder();
        }
        
        if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, 1 << LayerMask.NameToLayer("trampoline")) && isFalling)
        {
            Debug.Log("asff");
            TrampolineBounce();
        }
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

    private void TrampolineBounce()
    {
        rdbd.velocity += new Vector2(0, -rdbd.velocity.y);
        rdbd.velocity += Vector2.up * trampolineJumpHeight;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LadderTop" && (dir.y < 0))
        {
            Debug.Log("Gey");
            collision.gameObject.GetComponentInParent<LadderScript>().CanGoThrow();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            canClimb = true;
            rdbd.gravityScale = 0;
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

    private void MovementOnTheLadder()
    {
       
        rdbd.velocity = Vector2.zero;
        rdbd.transform.Translate(dir * Time.deltaTime * moveSpeed);
        
    }
}
