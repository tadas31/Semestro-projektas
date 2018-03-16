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

    public bool kj;

    private Vector3 dir;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundIsTouching = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundIsTouching = false;
        }
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
    }
}
