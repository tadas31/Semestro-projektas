﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GumScript : MonoBehaviour
{

    bool canFloat;
    public float floatSpeed;

    private GameObject gum;

    private float time;

    // Use this for initialization
    void Start()
    {
        time = 4.0f;
        canFloat = false;
        gum = GameObject.Find("GumBouble");
        gum.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LevelScript.gumButton.onClick.RemoveAllListeners();
        LevelScript.gumButton.onClick.AddListener(TaskOnGumClick);

        if (canFloat)
        {
            time -= Time.deltaTime;
            LevelScript.gumTimer.value = time;
        }

        if (time <= 0f)
        {
            LevelScript.gumTimer.gameObject.SetActive(false);
            gum.SetActive(false);
            canFloat = false;
            time = 4.0f;
        }
    }

    private void FixedUpdate()
    {
        if (canFloat)
        {
            PlayerMovement.rdbd.velocity = Vector2.zero;
            PlayerMovement.rdbd.transform.Translate(PlayerMovement.dir * Time.deltaTime * floatSpeed);

        }
    }

    /// <summary>
    /// allows character to float
    /// </summary>
    void TaskOnGumClick()
    {
        canFloat = true;
        gum.SetActive(true);
        LevelScript.gumButton.gameObject.SetActive(false);
        LevelScript.gumTimer.gameObject.SetActive(true);
        ClearOutSlot();
    }

    /// <summary>
    /// clears out slot 
    /// </summary>
    void ClearOutSlot()
    {
        if (CharacterScript.gum == 1)
            LevelScript.firstSlot = false;
        else if (CharacterScript.gum == 2)
            LevelScript.secondSlot = false;
        else if (CharacterScript.gum == 3)
            LevelScript.thirdSlot = false;
    }
}