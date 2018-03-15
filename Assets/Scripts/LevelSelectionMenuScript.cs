﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionMenuScript : MonoBehaviour {

    private Button back;
    private Button level_1;
    

	// Use this for initialization
	void Start () {
        back = GameObject.Find("Back").GetComponent<Button>();
        level_1 = GameObject.Find("Level1").GetComponent<Button>();

	}
	
	// Update is called once per frame
	void Update () {
        back.onClick.RemoveAllListeners();
        back.onClick.AddListener(TaskOnBackClick);

        level_1.onClick.RemoveAllListeners();
        level_1.onClick.AddListener(TaskOnLevel1Click);
    }

    void TaskOnBackClick()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

    void TaskOnLevel1Click()
    {
        SceneManager.LoadScene("Level1");
    }
}
