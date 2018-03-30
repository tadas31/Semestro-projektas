using System.Collections;
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
        // goes back to main menu
        back.onClick.RemoveAllListeners();
        back.onClick.AddListener(TaskOnBackClick);

        // loads level 1
        level_1.onClick.RemoveAllListeners();
        level_1.onClick.AddListener(TaskOnLevel1Click);
    }

    /// <summary>
    /// task on back click
    /// </summary>
    void TaskOnBackClick()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

    /// <summary>
    /// task on level 1 click
    /// </summary>
    void TaskOnLevel1Click()
    {
        SceneManager.LoadScene("Level1");
    }

    /// <summary>
    /// task on level 0 click
    /// </summary>
    void TaskOnTestClic()
    {
        SceneManager.LoadScene("Test");
    }
}
