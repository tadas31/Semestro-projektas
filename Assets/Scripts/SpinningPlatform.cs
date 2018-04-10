using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPlatform : MonoBehaviour {
    private Rigidbody2D rb2d;
    int turn = 0;
    public int speed;
    bool stop = false;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            turn += speed;
            rb2d.rotation = turn;
            if (turn == 360)
            {
                turn = 0;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            StopPlatform();
        }
    }

    private void StopPlatform()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (hit && hit.collider.tag == "SpinningPlatform")
        {
            hit.collider.GetComponent<SpinningPlatform>().Stop();
            hit.collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            hit.collider.tag = "PressedPlatform";
        }
    }

    public void Stop()
    {
        stop = true;
        PlatformScript.stoppedCount++;

    }

}
