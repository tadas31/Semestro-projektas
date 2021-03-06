﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public static Rigidbody2D rdbd;


    public float forceMultiplier;

    private Text candyCount;
    private Text platformCount;
    private Text platformCountText;
    private static int counter = 0;
    private int countPlat;

    // STATS
    public static float lives;
    int maxLives = 3;

    //slots
    public static int energyBar;
    public static int gum;
    public static int shield;

    //saves
    public SaveState state;


    // Use this for initialization
    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
        candyCount = GameObject.Find("CandyCount").GetComponent<Text>();
        platformCount = GameObject.Find("PlatformCount").GetComponent<Text>();
        platformCountText = GameObject.Find("PlatLeft").GetComponent<Text>();
        platformCount.text = PlatformScript.stoppableCount.ToString();
        counter = 0;
        lives = SaveManager.Instance.ReturnCharacterStats()[2];

    }

    // Update is called once per frame
    void Update()
    {
        countPlat = PlatformScript.stoppableCount - PlatformScript.stoppedCount;
        platformCount.text = countPlat.ToString();
        if (!cameraMovement.moveCamera)
        {
            platformCount.enabled = false;
            platformCountText.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Damage1" || collision.gameObject.tag == "EnemyDamage")
            doDamage();
        if (collision.gameObject.tag == "Damage_fatal" || collision.gameObject.tag == "FallingSpikes")
        {
            lives = 0;
            LevelScript.OnDeath();

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            collision.gameObject.SetActive(false);
            counter++;

            candyCount.text = counter.ToString();
            FindObjectOfType<AudioManager>().Play("Candy_pickup");
        }

        //energy bar pick up
        else if (collision.gameObject.tag == "EnergyBar")
        {
            collision.gameObject.SetActive(false);
            if (!LevelScript.energyBarButton.IsActive())
            {
                Vector2 pos;
                LevelScript.Position(out pos, out energyBar);
                if (energyBar != 0)
                {
                    LevelScript.energyBarButton.transform.position = pos;
                    LevelScript.energyBarButton.gameObject.SetActive(true);
                }
            }
            FindObjectOfType<AudioManager>().Play("Boost_pickup");
        }

        //gum pick up
        else if (collision.gameObject.tag == "Gum")
        {
            collision.gameObject.SetActive(false);
            if (!LevelScript.gumButton.IsActive() )
            {
                Vector2 pos;
                LevelScript.Position(out pos, out gum);
                if (gum != 0)
                {
                    LevelScript.gumButton.transform.position = pos;
                    LevelScript.gumButton.gameObject.SetActive(true);
                }
                
            }
            FindObjectOfType<AudioManager>().Play("Boost_pickup");
        }

        //shield pick up
        else if (collision.gameObject.tag == "Shield")
        {
            collision.gameObject.SetActive(false);
            if (!LevelScript.shieldButton.IsActive())
            {
                Vector2 pos;
                LevelScript.Position(out pos, out shield);
                if (shield != 0)
                {
                    LevelScript.shieldButton.transform.position = pos;
                    LevelScript.shieldButton.gameObject.SetActive(true);
                }

            }
            FindObjectOfType<AudioManager>().Play("Boost_pickup");
        }

        if (collision.gameObject.tag == "Heart")
        {
            collision.gameObject.SetActive(false);
            if (lives < maxLives)
            {
                lives++;
            }
            FindObjectOfType<AudioManager>().Play("Boost_pickup");
        }

        if (collision.gameObject.tag == "Enemy_top")
        {
            EnemyMovement.stunned = true;
            StartCoroutine(Knockback(0.001f, 50, rdbd.transform.position));
        }
    }

    /// <summary>
    /// get's candy count
    /// </summary>s
    /// <returns></returns>
    public static int getCandyCount()
    {
        return counter;
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
        rdbd.velocity = new Vector2(rdbd.velocity.x, 0);
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rdbd.AddForce(new Vector3(knockbackDir.x * -20, knockbackDir.y * knockbackPwr, rdbd.transform.position.z));
        }
        yield return 0;
    }

    public void doDamage()
    {
        if (!ShieldScript.shieldActive)
            lives--;
        StartCoroutine(Knockback(0.02f, 50, rdbd.transform.position));
        if (lives == 0)
            LevelScript.OnDeath();
        FindObjectOfType<AudioManager>().Play("Damage");
    }
}
