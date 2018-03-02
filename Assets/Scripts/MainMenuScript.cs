using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {


    private Button levelSelection;
    private Button settings;

	void Start () {
        Scene[] scenes = SceneManager.GetAllScenes();
        

        if (scenes[0].name.Equals("SettingsMenu"))
            SceneManager.UnloadScene("SettingsMenu");

        else if (scenes[0].name.Equals("LevelSelectionMenu"))
            SceneManager.UnloadScene("LevelSelectionMenu");

        levelSelection = GameObject.Find("LevelSelectionMenu").GetComponent<Button>();
        settings = GameObject.Find("Settings").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        levelSelection.onClick.RemoveAllListeners();
        levelSelection.onClick.AddListener(TaskOnLevelSelectionClick);

        settings.onClick.RemoveAllListeners();
        settings.onClick.AddListener(TaskOnSettingsClick);
    }

    void TaskOnLevelSelectionClick()
    {
        SceneManager.LoadScene("LevelSelectionMenu", LoadSceneMode.Additive);
    }

    void TaskOnSettingsClick()
    {
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Additive);
    }


}
