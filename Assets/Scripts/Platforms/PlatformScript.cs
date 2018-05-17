using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformScript : MonoBehaviour
{

    public float speed;
    public float lenghtX;
    public float lenghtY;
    public bool moveByX;
    public bool moveByY;
    bool byX;
    bool byY;
    bool stop = false;

    float x;
    float y;
    public static int stoppedCount;
    public static int stoppableCount;

    
    GameObject[] stoppablePlat;
    GameObject[] stoppablePlatSpin;
    
    // Use this for initialization
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        stoppedCount = 0;

        stoppablePlat = GameObject.FindGameObjectsWithTag("MovingPlatform");


        stoppablePlatSpin = GameObject.FindGameObjectsWithTag("SpinningPlatform");
        stoppableCount = stoppablePlat.Length + stoppablePlatSpin.Length;


        Debug.Log(stoppableCount);
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        
        if (Input.GetMouseButtonDown(0))
        {
            StopPlatform();
        }
        Debug.Log(stoppedCount);
    }

    private void Movement()
    {
        if (!stop)
        {
            if (moveByX)
            {
                if (byX)
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                else
                    transform.Translate(-Vector2.right * speed * Time.deltaTime);

                if (transform.position.x >= lenghtX + x)
                {
                    byX = false;
                }

                if (transform.position.x <= -lenghtX + x)
                {
                    byX = true;
                }
            }

            if (moveByY)
            {
                if (byY)
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                else
                    transform.Translate(-Vector2.up * speed * Time.deltaTime);

                if (transform.position.y >= lenghtY + y)
                {
                    byY = false;
                }

                if (transform.position.y <= -lenghtY + y)
                {
                    byY = true;
                }
            }

        }

    }

    private void StopPlatform()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        if (hit && hit.collider.tag == "MovingPlatform")
        {
            hit.collider.GetComponent<PlatformScript>().Stop();
            hit.collider.tag = "PressedPlatform";
            hit.collider.GetComponent<Animator>().enabled = true;
        }
    }

    public void Stop()
    {
        stop = true;
        stoppedCount++;
    }

}

