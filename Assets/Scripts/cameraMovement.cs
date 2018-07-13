using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject player;
    public Transform startBoundary;
    public Transform endBoundary;
    public Transform topBoundary;
    public Transform bottomBoundary;

    private Vector3 offset;
    private Vector3 startPos;
    private float x;
    public static bool moveCamera;    // True - joystick moves camera, false - player

    public JoystickMovement JsMovement;
    private Vector3 dir;
    private float start;
    private float end;
    private float top;
    private float bottom;

    void Start()
    {
        offset = transform.position - player.transform.position; // Gap between camera and player
        startPos = transform.position - new Vector3(3,0,0);                           // Cameras starting position
        transform.position = transform.position + new Vector3(1, 0, 0);
        moveCamera = true;

        start = startBoundary.transform.position.x + 2f;
        end = endBoundary.transform.position.x - 2f;

        top = topBoundary.transform.position.y - 2f;
        bottom = bottomBoundary.transform.position.y + 7f;
}

    // Update is called once per frame
    void Update () {
        dir = JsMovement.InputDirection;  // Joystick input

        if (moveCamera)
        {
            //if (transform.position.x > start)
            //    transform.Translate(new Vector2(dir.x / 5, 0.0f));   // Moves camera
            //else
            //    transform.position = new Vector3(startBoundary.transform.position.x + 2f, startPos.y, -10);
            if (dir.x < -0.3)
            {
                dir.x = -1;
                if (transform.position.x > start)
                    transform.Translate(new Vector2(dir.x / 15, 0));   // Moves camera
                else
                    transform.position = new Vector3(startBoundary.transform.position.x + 2f, gameObject.transform.position.y, -10);

                if (transform.position.x < end)
                    transform.Translate(new Vector2(dir.x / 15, 0));   // Moves camera
                else
                    transform.position = new Vector3(endBoundary.transform.position.x - 2f, gameObject.transform.position.y, -10);
            }
            if (dir.x > 0.3)
            {
                dir.x = 1;
                if (transform.position.x > start)
                    transform.Translate(new Vector2(dir.x / 15, 0));   // Moves camera
                else
                    transform.position = new Vector3(startBoundary.transform.position.x + 2f, gameObject.transform.position.y, -10);

                if (transform.position.x < end)
                    transform.Translate(new Vector2(dir.x / 15, 0));   // Moves camera
                else
                    transform.position = new Vector3(endBoundary.transform.position.x - 2f, gameObject.transform.position.y, -10);
            }

            if (dir.y > 0.3)
            {
                dir.y = 1;
                if (transform.position.y < top)
                    transform.Translate(new Vector2(0, dir.y / 30));   // Moves camera
                else
                    transform.position = new Vector3(gameObject.transform.position.x, topBoundary.transform.position.y - 2f, -10);

                if (transform.position.y > bottom)
                    transform.Translate(new Vector2(0, dir.y / 30));   // Moves camera
                else
                    transform.position = new Vector3(gameObject.transform.position.x, bottomBoundary.transform.position.y + 7f, -10);
                Debug.Log("ZONA");
            }

            if (dir.y < -0.3)
            {
                dir.y = -1;
                if (transform.position.y < top)
                    transform.Translate(new Vector2(0, dir.y / 30));   // Moves camera
                else
                    transform.position = new Vector3(gameObject.transform.position.x, topBoundary.transform.position.y - 2f, -10);

                if (transform.position.y > bottom)
                    transform.Translate(new Vector2(0, dir.y / 30));   // Moves camera
                else
                    transform.position = new Vector3(gameObject.transform.position.x, bottomBoundary.transform.position.y + 7f, -10);
                Debug.Log("ZONA");
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                // Move object across X plane
                transform.Translate(new Vector2(-touchDeltaPosition.x/(Screen.width /8), 0));
            }
        }
        else
            gameObject.transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y, startPos.z);

        //was camera moved used in tutorial
        if (transform.position != new Vector3(1.2f, 0.85f, -10))
            TutorialScript.wasCameraMoved = true;
    }

}
