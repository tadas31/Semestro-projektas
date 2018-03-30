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
        settingsPopUp = GameObject.Find("SettingsPopUp");
        settingsPopUp.active = false;

        levelSelection = GameObject.Find("LevelSelectionMenu").GetComponent<Button>();
        settings = GameObject.Find("Settings").GetComponent<Button>();

        Information = GameObject.Find("Information").GetComponent<Button>();
        informationPopUp = GameObject.Find("InformationPopUp");
        informationPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        levelSelection.onClick.RemoveAllListeners();
        levelSelection.onClick.AddListener(TaskOnLevelSelectionClick);

        //onepn settings
        settings.onClick.AddListener(TaskOnSettingsClick);

        //close settings
        if (settingsPopUp.active == true)
        {
            int id = Input.GetTouch(0).fingerId;
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(id))
                TaskOnSettingsExitClick();
            settingsExit.onClick.RemoveAllListeners();
            settingsExit.onClick.AddListener(TaskOnSettingsExitClick);
        }

        //open information
        Information.onClick.AddListener(TaskOnInformationClicl);

        //close information
        if (informationPopUp.active == true)
        {
            int id = Input.GetTouch(0).fingerId;
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(id))
                TaskOnInfromationExitClick();

            Information.onClick.RemoveAllListeners();
            Information.onClick.AddListener(TaskOnInfromationExitClick);
        }

    }

    /// <summary>
    /// takes user to level selection menu
    /// </summary>
    void TaskOnLevelSelectionClick()
    {
        SceneManager.LoadScene("LevelSelectionMenu");
    }

    /// <summary>
    /// opens settings popup
    /// </summary>
    void TaskOnSettingsClick()
    {
        levelSelection.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        settingsPopUp.active = true;
        settingsExit = GameObject.Find("settingsExit").GetComponent<Button>();
    }

    /// <summary>
    /// closes settings popup
    /// </summary>
    void TaskOnSettingsExitClick()
    {
        settingsPopUp.active = false;
        levelSelection.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
    }

    /// <summary>
    /// opens information popup
    /// </summary>
    void TaskOnInformationClicl()
    {
        if (settingsPopUp.active == true)
            settingsPopUp.active = false;

        levelSelection.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        informationPopUp.SetActive(true);
    }

    /// <summary>
    /// closes information popup
    /// </summary>
    void TaskOnInfromationExitClick()
    {
        levelSelection.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        informationPopUp.SetActive(false);
    }
}
