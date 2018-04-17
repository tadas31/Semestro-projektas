using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionMenuScript : MonoBehaviour {



    //public Transform levelPanel;
    //public RectTransform menuContainer;

    private Button back;
    private Button tutorial;
    private Button level_1;
    

	// Use this for initialization
	void Start () {
        back = GameObject.Find("Back").GetComponent<Button>();
        tutorial = GameObject.Find("Tutorial").GetComponent<Button>();
        level_1 = GameObject.Find("Level1").GetComponent<Button>();

        
    }
	
	// Update is called once per frame
	void Update () {
        // goes back to main menu
        back.onClick.RemoveAllListeners();
        back.onClick.AddListener(TaskOnBackClick);

        // loads tutorial
        tutorial.onClick.RemoveAllListeners();
        tutorial.onClick.AddListener(TaskOnTutorialClick);

        // loads level 1
        level_1.onClick.RemoveAllListeners();
        level_1.onClick.AddListener(TaskOnLevel1Click);
    }

    /// <summary>
    /// takes user back to main menu
    /// </summary>
    void TaskOnBackClick()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

    /// <summary>
    /// takes user to tutorial
    /// </summary>
    void TaskOnTutorialClick()
    {
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// takes user to level 1
    /// </summary>
    void TaskOnLevel1Click()
    {
        SceneManager.LoadScene("Level1");
    }
}
