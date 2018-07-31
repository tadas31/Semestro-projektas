using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlatform : MonoBehaviour {


    public static bool isPoped;
    public static bool active = false;


    public float height;

    // Use this for initialization
    void Start () {
        isPoped = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            gameObject.GetComponent<BubblePlatform>().StartCoroutine(ShowAndHide());
        }
    }

    IEnumerator ShowAndHide()
    {
        isPoped = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Animator>().Play("BubblePlatform_Pop");
        GetComponent<Collider2D>().enabled = false;
    }

}
