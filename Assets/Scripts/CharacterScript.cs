using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    private Rigidbody2D rdbd;
    public float forceMultiplier;

    private Text candyCount;
    private int counter = 0;

    Vector2 startPos;

    // STATS
    public static int lives = 3;


    // Use this for initialization
    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
        candyCount = GameObject.Find("CandyCount").GetComponent<Text>();
        startPos = rdbd.position;
    }

    // Update is called once per frame
    void Update()
    {
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Damage1")
        {
            lives--;
            Vector2 knockbackVelocity = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * forceMultiplier,
                (transform.position.y - collision.gameObject.transform.position.y) * forceMultiplier);
            Debug.Log(knockbackVelocity);
            rdbd.velocity = -knockbackVelocity;

            if (lives == 0) //When lives = 0, die (restart level for now)
                Die();

            Debug.Log("--------------- " + lives);
        }
        Debug.Log("character script " + lives);
        if (collision.gameObject.tag == "Damage_fatal")
            Die();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            collision.gameObject.active = false;
            counter++;
            candyCount.text = counter.ToString();
        }

    }

    void Die()
    {
        // Restart
        rdbd.transform.position = startPos;
        lives = 3;
        //Application.LoadLevel(Application.loadedLevel);
    }
}
