using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    //saves
    private Text candyCount;

    //main menu
    private Button levelSelection;
    private Button settings;
    private Button settingsExit;
    private Button Information;
    private GameObject informationPopUp;
    private GameObject settingsPopUp;


    void Start()
    {

        // main menu
        levelSelection = GameObject.Find("LevelSelection").GetComponent<Button>();
        settings = GameObject.Find("Settings").GetComponent<Button>();

        Information = GameObject.Find("Information").GetComponent<Button>();

        settingsPopUp = GameObject.Find("SettingsPopUp");
        settingsPopUp.SetActive(false);

        informationPopUp = GameObject.Find("InformationPopUp");
        informationPopUp.SetActive(false);

        candyCount = GameObject.Find("Candy").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        candyCount.text = SaveManager.Instance.ReturnCandy().ToString();

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
        Information.onClick.AddListener(TaskOnInformationClick);

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
    /// opens settings popup
    /// </summary>
    public void TaskOnSettingsClick()
    {
        levelSelection.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        settingsPopUp.active = true;
        settingsExit = GameObject.Find("settingsExit").GetComponent<Button>();
    }

    /// <summary>
    /// closes settings popup
    /// </summary>
    public void TaskOnSettingsExitClick()
    {
        settingsPopUp.active = false;
        levelSelection.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
    }

    /// <summary>
    /// opens information popup
    /// </summary>
    public void TaskOnInformationClick()
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
    public void TaskOnInfromationExitClick()
    {
        levelSelection.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        informationPopUp.SetActive(false);
    }
}
