using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    private GameObject shield;

    private float time;

    public static bool shieldActive = false;

    // Use this for initialization
    void Start () {
        time = SaveManager.Instance.ReturnBoostsDuration()[2];
        shield = GameObject.Find("ShieldBouble");
        shield.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {
        LevelScript.shieldButton.onClick.RemoveAllListeners();
        LevelScript.shieldButton.onClick.AddListener(TaskOnShieldClick);

        if (shieldActive)
        {
            time -= Time.deltaTime;
            LevelScript.shieldTimer.value = time;
        }

        if (time <= 0f)
        {
            LevelScript.shieldTimer.gameObject.SetActive(false);
            shield.SetActive(false);
            shieldActive = false;
            time = SaveManager.Instance.ReturnBoostsDuration()[2];
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (shieldActive)
        {
            if (collision.gameObject.tag == "EnemyDamage")
            {
                LevelScript.shieldTimer.gameObject.SetActive(false);
                EnemyMovement.stunned = true;
                shieldActive = false;
                shield.SetActive(false);
                time = 10.0f;
            }
            else if (collision.gameObject.tag == "Damage1" || collision.gameObject.tag == "Damage_fatal")
            {
                LevelScript.shieldTimer.gameObject.SetActive(false);
                shieldActive = false;
                shield.SetActive(false);
                time = 10.0f;
            }
            else
                Physics2D.IgnoreCollision(collision.collider, shield.GetComponent<Collider2D>());
        }

    }

    /// <summary>
    /// activates shield
    /// </summary>
    void TaskOnShieldClick()
    {
        shieldActive = true;
        shield.SetActive(true);
        LevelScript.shieldButton.gameObject.SetActive(false);
        LevelScript.shieldTimer.gameObject.SetActive(true);
        ClearOutSlot();
        FindObjectOfType<AudioManager>().Play("Use_boost");
    }

    /// <summary>
    /// clears out slot 
    /// </summary>
    void ClearOutSlot()
    {
        if (CharacterScript.shield == 1)
            LevelScript.firstSlot = false;
        else if (CharacterScript.shield == 2)
            LevelScript.secondSlot = false;
        else if (CharacterScript.shield == 3)
            LevelScript.thirdSlot = false;
    }
}
