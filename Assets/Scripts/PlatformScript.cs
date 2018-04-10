using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    GameObject[] fadingPlatform;
    GameObject[] stoppablePlat;
    GameObject[] stoppablePlatSpin;
    float disapear;
    // Use this for initialization
    void Start()
    {
        fadingPlatform = GameObject.FindGameObjectsWithTag("FadingGround");
        disapear = 2.9f;
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

        disapear -= Time.deltaTime;

        if (disapear <= 0.0f)
        {
            StartCoroutine(ShowAndHide());
            disapear = 2.9f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StopPlatform();
        }
        Debug.Log(stoppedCount);
    }


    IEnumerator ShowAndHide()
    {
        foreach (var platform in fadingPlatform)
            platform.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2.05f);
        foreach (var platform in fadingPlatform)
            platform.GetComponent<Collider2D>().enabled = true;
        disapear = 2.9f;
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
        }
    }

    public void Stop()
    {
        stop = true;
        stoppedCount++;
    }

}

