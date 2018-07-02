using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour, IPointerDownHandler
{

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public bool isGrounded()
    {
        return grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isGrounded() && !cameraMovement.moveCamera && LevelScript.canMove)              // Player jumps when screen button is pressed
        {
            PlayerMovement.Jump();
        }
    }
}
