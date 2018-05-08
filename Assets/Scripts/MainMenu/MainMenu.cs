using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class MainMenu : MonoBehaviour {

    //saves
    private Text candyCount;

    //main menu
    private Button levelSelection;
    private Button settings;
    private Button settingsExit;
    private Button Information;
    private Button shop;
    private GameObject informationPopUp;
    private GameObject settingsPopUp;

    //settings
    private Button resetGame;
    private GameObject confirmation;
    private Button yes;
    private Button no;
    public static Toggle mute;
    public static bool settingsActive;
    private string muteString;

    void Start()
    {

        // main menu
        levelSelection = GameObject.Find("LevelSelection").GetComponent<Button>();
        settings = GameObject.Find("Settings").GetComponent<Button>();

        Information = GameObject.Find("Information").GetComponent<Button>();

        shop = GameObject.Find("Shop").GetComponent<Button>();

        settingsPopUp = GameObject.Find("SettingsPopUp");
        settingsPopUp.SetActive(false);

        informationPopUp = GameObject.Find("InformationPopUp");
        informationPopUp.SetActive(false);

        candyCount = GameObject.Find("ManiMenuCandy").GetComponentInChildren<Text>();

        confirmation = GameObject.Find("Confirmation");
        confirmation.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        candyCount.text = SaveManager.Instance.ReturnCandy().ToString();

        //open settings
        settings.onClick.RemoveAllListeners();
        settings.onClick.AddListener(TaskOnSettingsClick);

        //close settings
        if (settingsPopUp.active == true)
        {
            int id = Input.GetTouch(0).fingerId;
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(id)) 
                TaskOnSettingsExitClick();

            SaveManager.Instance.SetMute(mute.isOn);

            resetGame.onClick.RemoveAllListeners();
            resetGame.onClick.AddListener(TaskOnResetProgressClick);

            settingsExit.onClick.RemoveAllListeners();
            settingsExit.onClick.AddListener(TaskOnSettingsExitClick);
            
        }

        if (confirmation.active == true)
        {
            yes.onClick.RemoveAllListeners();
            yes.onClick.AddListener(TaskOnYesClick);
            no.onClick.RemoveAllListeners();
            no.onClick.AddListener(TaskOnNoClick);
        }

        //open information
        Information.onClick.RemoveAllListeners();
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
        levelSelection.interactable = false;
        settings.interactable = false;
        Information.interactable = false;
        shop.interactable = false;

        settingsPopUp.active = true;
        settingsExit = GameObject.Find("settingsExit").GetComponent<Button>();
        resetGame = GameObject.Find("ResetGame").GetComponent<Button>();
        mute = GameObject.Find("Mute").GetComponent<Toggle>();
        mute.isOn = SaveManager.Instance.ReturnMute();

        // muteString = mute.ToString();

        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// closes settings popup
    /// </summary>
    public void TaskOnSettingsExitClick()
    {
        settingsPopUp.active = false;

        levelSelection.interactable = true;
        settings.interactable = true;
        Information.interactable = true;
        shop.interactable = true;
    }

    /// <summary>
    /// opens information popup
    /// </summary>
    public void TaskOnInformationClick()
    {
        levelSelection.interactable = false;
        settings.interactable = false;
        shop.interactable = false;

        informationPopUp.SetActive(true);

        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// closes information popup
    /// </summary>
    public void TaskOnInfromationExitClick()
    {
        levelSelection.interactable = true;
        settings.interactable = true;
        shop.interactable = true;

        informationPopUp.SetActive(false);
    }
    
    /// <summary>
    /// asks if you want to reset your progress
    /// </summary>
    private void TaskOnResetProgressClick()
    {
        confirmation.SetActive(true);
        yes = GameObject.Find("Yes").GetComponent<Button>();
        no = GameObject.Find("No").GetComponent<Button>();
        settingsPopUp.SetActive(false);

        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// resets progres
    /// </summary>
    private void TaskOnYesClick()
    {
        SaveManager.Instance.ResetSave();
        SaveManager.Instance.Load();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// goes back to settings
    /// </summary>
    private void TaskOnNoClick()
    {
        levelSelection.interactable = true;
        settings.interactable = true;
        Information.interactable = true;
        shop.interactable = true;

        confirmation.SetActive(false);

        FindObjectOfType<AudioManager>().Play("Button_press");
    }
}
