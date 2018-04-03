using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public static Rigidbody2D rdbd;


    public float forceMultiplier;

    private Text candyCount;
    private int counter = 0;

    // STATS
    public static int lives;


    // Use this for initialization
    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
        candyCount = GameObject.Find("CandyCount").GetComponent<Text>();
        lives = 3;
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
            if (lives == 0) //When lives = 0, die (restart level for now)
                LevelScript.OnDeath();
            StartCoroutine(Knockback(0.02f, 50, rdbd.transform.position));
            Debug.Log("--------------- " + lives);
        }
        Debug.Log("character script " + lives);
        if (collision.gameObject.tag == "Damage_fatal")
            LevelScript.OnDeath();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            collision.gameObject.SetActive(false);
            counter++;
            candyCount.text = counter.ToString();
        }
        else if (collision.gameObject.tag == "EnergyBar")
        {
            collision.gameObject.SetActive(false);
            LevelScript.energyBar.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Knockbacks player when he/she hits a damaging obstacle
    /// </summary>
    /// <param name="knockDur"></param>
    /// <param name="knockbackPwr"></param>
    /// <param name="knockbackDir"></param>
    /// <returns></returns>
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rdbd.AddForce(new Vector3(knockbackDir.x * -20, knockbackDir.y * knockbackPwr, rdbd.transform.position.z));
        }
        yield return 0;
    }
}
