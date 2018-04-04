﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rdbd;

    public float maxSpeed;   // Max player movement speed, used to limit its velocity
    public float moveSpeedJ; // Player movement speed
    public float jumpHeight; 
    public float drag;
    
    private bool canClimb;
    private bool isClimbing;

    public JoystickMovement jsMovement;
    private Vector3 dir;    // Joystick direction
    private Vector3 dirAir;

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    private bool isFalling;
    public float trampolineJumpHeight;

    public Animator Animator;
    bool facingRight = true;

    

    // Use this for initialization
    void Start () {
        rdbd = GetComponent<Rigidbody2D>();
        Animator.SetBool("IsGrounded", true);
    }

    // Update is called once per frame
    void Update () {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space)) // Player jumps when SPACE keyboard button is pressed
        {
            Debug.Log("Space");
            Jump();
        }
        LevelScript.jumButton.onClick.RemoveAllListeners();
        if (isGrounded() && !cameraMovement.moveCamera)              // Player jumps when screen button is pressed
        {
            LevelScript.jumButton.onClick.AddListener(Jump);
        }

        CheckIfFalling();                                    // Checking if player is falling
      
        if(rdbd.velocity.magnitude > maxSpeed)               // Limiting player movements speed
        {
            rdbd.velocity = Vector2.ClampMagnitude(rdbd.velocity, maxSpeed);
            
        }

        if (!cameraMovement.moveCamera)
        {
            if (!isGrounded()) // Sets direction to 0, so when jumping jumping animation activates
                dirAir.x = 0;
            if (dir.x < 0 && facingRight)
                Flip();
            else if (dir.x > 0 && !facingRight)
                Flip();

            Animator.SetBool("IsGrounded", isGrounded());       // For jumping animation
            Animator.SetFloat("Speed", Mathf.Abs(dirAir.x));    // For running animation
        }
    }

    /// <summary>
    /// Flips the player according to joystick position
    /// </summary>
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        rdbd.transform.localScale = theScale;
    }

    void Jump()
    {
        rdbd.AddForce(new Vector2(0, jumpHeight));       
    }

    bool isGrounded()
    {
        return grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    private void FixedUpdate()
    {
        
        dir = jsMovement.InputDirection;
        dirAir = dir;
        
        if (isGrounded() && !cameraMovement.moveCamera)  // Player can be moved when it's on the ground and when camera movement is false
        {
            rdbd.velocity += new Vector2(dir.x / moveSpeedJ, 0);
            rdbd.drag = drag;                    // To reduce sliding
        }
        else rdbd.drag = 0;

        if (canClimb && dir.y > 0.3f)
        {
            isClimbing = true;
        }

        if (isClimbing)
        {
            MovementOnTheLadder();
        }

        
        //if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, 1 << LayerMask.NameToLayer("trampoline")) && isFalling)
        //{
        //    TrampolineBounce();
        //}
    }

    /// <summary>
    /// Checking if player is currently falling
    /// </summary>
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

    /// <summary>
    /// Player bounces when it jumps on a trampoline
    /// </summary>
    private void TrampolineBounce(float height)
    {
        Debug.Log("Heigth " + height);
        Debug.Log(rdbd.velocity.y);
        rdbd.velocity += new Vector2(0, -rdbd.velocity.y);
        rdbd.AddForce(new Vector2(0, height));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LadderTop" && (dir.y < 0))
        {
            collision.gameObject.GetComponentInParent<LadderScript>().CanGoThrow();
            canClimb = true;
            isClimbing = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline" && isFalling)
        {
            TrampolineBounce(collision.gameObject.GetComponent<TrampolineScript>().height);
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
        if (collision.gameObject.tag == "Ladder" || (collision.gameObject.tag == "LadderTop" && dir.y > 0))
        {
            canClimb = false;
            isClimbing = false;
            collision.gameObject.GetComponent<LadderScript>().CannotGoThrow();
            rdbd.gravityScale = 1;
        }
    }


    /// <summary>
    /// Player moves on a ladder
    /// </summary>
    private void MovementOnTheLadder()
    {      
        rdbd.velocity = Vector2.zero;
        rdbd.transform.Translate(dir * Time.deltaTime * moveSpeedJ);
        //rdbd.velocity += new Vector2(dir.x / moveSpeedJ, dir.y / moveSpeedJ);
    }

}
