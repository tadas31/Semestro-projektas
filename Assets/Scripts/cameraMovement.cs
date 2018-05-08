using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject player;
    public Transform startBoundary;
    public Transform endBoundary;

    private Vector3 offset;
    private Vector3 startPos;
    private float x;
    public static bool moveCamera;    // True - joystick moves camera, false - player

    public JoystickMovement JsMovement;
    private Vector3 dir;
    private float start;
    private float end;

    void Start()
    {
        offset = transform.position - player.transform.position; // Gap between camera and player
        startPos = transform.position - new Vector3(3,0,0);                           // Cameras starting position
        transform.position = transform.position + new Vector3(1, 0, 0);
        moveCamera = true;

        start = startBoundary.transform.position.x + 2f;
        end = endBoundary.transform.position.x - 2f;
    }

    // Update is called once per frame
    void Update () {
        dir = JsMovement.InputDirection;  // Joystick input

        if (moveCamera)
        {
            if (transform.position.x > start)
                transform.Translate(new Vector2(dir.x / 5, 0.0f));   // Moves camera
            else
                transform.position = new Vector3(startBoundary.transform.position.x + 2f, startPos.y, -10);

            if (transform.position.x < end)               
                transform.Translate(new Vector2(dir.x / 5, 0.0f));   // Moves camera
            else
                transform.position = new Vector3(endBoundary.transform.position.x - 2f, startPos.y, -10);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                // Move object across X plane
                transform.Translate(new Vector2(-touchDeltaPosition.x/(Screen.width /8), 0));
            }
        }
        else 
            transform.position = new Vector3(player.transform.position.x + offset.x, startPos.y, startPos.z);  // Resets camera position
    }

}
