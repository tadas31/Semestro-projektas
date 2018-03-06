using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour {


    private Button levelSelection;
    private Button settings;

    private Button settingsExit;
    private GameObject settingsPopUp;

    private Button Information;
    private GameObject informationPopUp;

	void Start () {
        Scene[] scenes = SceneManager.GetAllScenes();

        if (scenes[0].name.Equals("SettingsMenu"))
            SceneManager.UnloadScene("SettingsMenu");

        else if (scenes[0].name.Equals("LevelSelectionMenu"))
            SceneManager.UnloadScene("LevelSelectionMenu");

        settingsPopUp = GameObject.Find("SettingsPopUp");
        settingsPopUp.active = false;

        levelSelection = GameObject.Find("LevelSelectionMenu").GetComponent<Button>();
        settings = GameObject.Find("Settings").GetComponent<Button>();

        Information = GameObject.Find("Information").GetComponent<Button>();
        informationPopUp = GameObject.Find("InformationPopUp");
        informationPopUp.active = false;
    }

    // Update is called once per frame
    void Update () {
        levelSelection.onClick.RemoveAllListeners();
        levelSelection.onClick.AddListener(TaskOnLevelSelectionClick);

        settings.onClick.AddListener(TaskOnSettingsClick);
        if (settingsPopUp.active == true)
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
                TaskOnSettingsExitClick();
            settingsExit.onClick.AddListener(TaskOnSettingsExitClick);
        }

        Information.onClick.AddListener(TaskOnInformationClicl);
        if (informationPopUp.active == true)
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
                TaskOnInfromationExitClick();
            Information.onClick.AddListener(TaskOnInfromationExitClick);
        }

    }

    void TaskOnLevelSelectionClick()
    {
        SceneManager.LoadScene("LevelSelectionMenu", LoadSceneMode.Additive);
    }

    void TaskOnSettingsClick()
    {
        levelSelection.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        settingsPopUp.active = true;
        settingsExit = GameObject.Find("settingsExit").GetComponent<Button>();
    }

    void TaskOnSettingsExitClick()
    {
        settingsPopUp.active = false;
        levelSelection.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
    }

    void TaskOnInformationClicl()
    {
        if (settingsPopUp.active == true)
            settingsPopUp.active = false;

        levelSelection.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        informationPopUp.active = true;
    }

    void TaskOnInfromationExitClick()
    {
        levelSelection.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        informationPopUp.active = false;
    }
}
