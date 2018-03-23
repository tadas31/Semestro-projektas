using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private Vector3 startPos;
    private float x;
    public bool moveCamera;    // True - joystick moves camera, false - player

    public JoystickMovement JsMovement;
    private Vector3 dir;

    void Start()
    {
        offset = transform.position - player.transform.position; // Gap between camera and player
        startPos = transform.position;                           // Cameras starting position
        transform.position = transform.position + new Vector3(1, 0, 0);
        moveCamera = true;
    }

    // Update is called once per frame
    void Update () {
        dir = JsMovement.InputDirection;  // Joystick input
        if (PlatformScript.stoppedCount == 2)  // Checks if all the stoppable platforms are stopped
            moveCamera = false;
        if (moveCamera)
            transform.Translate(new Vector2(dir.x / 5, 0.0f));   // Moves camera
        else
            transform.position = new Vector3(player.transform.position.x + offset.x, startPos.y, startPos.z);  // Resets camera position

    }
}
