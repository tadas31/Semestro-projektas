using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Rigidbody2D rdbd;
    public float speed;
    public float maxSpeed;
    float time;

    bool facingRight = true;
    public static bool stunned = false;
    public bool stunnedAnim = false;

    public Animator animator;
	// Use this for initialization
	void Start () {
        rdbd = GetComponent<Rigidbody2D>();
        time = 5.0f;
    }

    private void Update()
    {
        animator.SetBool("Stunned", stunned);
        if (rdbd.velocity.magnitude > maxSpeed)               // Limiting player movements speed
            rdbd.velocity = Vector2.ClampMagnitude(rdbd.velocity, maxSpeed);

        if (stunned)
        {
            time -= Time.deltaTime;
        }

        if(time <= 0f)
        {
            time = 5f;
            stunned = !stunned;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(!stunned)
            rdbd.velocity += new Vector2(speed, 0);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightWayPoint" && facingRight)
        {
            Flip();
        }
        if (collision.gameObject.tag == "LeftWayPoint" && !facingRight)
            Flip();       
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        rdbd.transform.localScale = theScale;
        speed *= -1;
    }
}
