//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using UnityEngine.EventSystems;

//public class MainMenuScript : MonoBehaviour {

//    //level selection
//    public Transform levelPanel;
//    public RectTransform menuContainer;
//    private Vector2 desiredMenuPosition;

//    //saves
//    public SaveState state;
//    private Text savesss;

//    //main menu
//    //private Button levelSelection;
//    //private Button settings;
//    //private Button settingsExit;
//    //private GameObject settingsPopUp;
//    //private Button Information;
//    //private GameObject informationPopUp;

//	void Start () {

//        //// main menu
//        //settingsPopUp = GameObject.Find("SettingsPopUp");
//        //settingsPopUp.active = false;

//        ////levelSelection = GameObject.Find("LevelSelectionMenu").GetComponent<Button>();

//        //settings = GameObject.Find("Settings").GetComponent<Button>();

//        //Information = GameObject.Find("Information").GetComponent<Button>();
//        //informationPopUp = GameObject.Find("InformationPopUp");
//        //informationPopUp.SetActive(false);


//        //savesss = GameObject.Find("Text").GetComponent<Text>();



//        // Add buttons on click event to levels
//        InitLevel();
//    }

//    // Update is called once per frame
//    void Update () {

//        //savesss.text = SaveManager.Instance.ReturnCandy().ToString();

//        //levelSelection.onClick.RemoveAllListeners();
//        //levelSelection.onClick.AddListener(TaskOnLevelSelectionClick);

//        //levelSelection.onClick.AddListener(TaskOnLevelSelectionClick);

//        //onepn settings
//        //settings.onClick.AddListener(TaskOnSettingsClick);

//        //close settings
//        //if (settingsPopUp.active == true)
//        //{
//        //    int id = Input.GetTouch(0).fingerId;
//        //    if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(id))
//        //        TaskOnSettingsExitClick();
//        //    settingsExit.onClick.RemoveAllListeners();
//        //    settingsExit.onClick.AddListener(TaskOnSettingsExitClick);
//        //}

//        //open information
//        //Information.onClick.AddListener(TaskOnInformationClicl);

//        ////close information
//        //if (informationPopUp.active == true)
//        //{
//        //    int id = Input.GetTouch(0).fingerId;
//        //    if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(id))
//        //        TaskOnInfromationExitClick();

//        //    Information.onClick.RemoveAllListeners();
//        //    Information.onClick.AddListener(TaskOnInfromationExitClick);
//        //}


//        // Menu navigation
//        menuContainer.anchoredPosition = Vector2.Lerp(menuContainer.anchoredPosition, desiredMenuPosition, 0.1f);

//    }


//    private void NavigateTo(int manuIndex)
//    {
//        switch (manuIndex)
//        {
//            // 0 = Mani menu
//            default:
//            case 0:
//                desiredMenuPosition = Vector2.zero;
//                break;
//            // 1 = level selection menu
//            case 1:
//                desiredMenuPosition = Vector2.right * -1920;
//                break;
//        }
//    }

//    public void OnBackClick()
//    {
//        NavigateTo(0);
//        Debug.Log("Back button has been clicked");
//    }

//    private void InitLevel()
//    {
//        if (levelPanel == null)
//            Debug.Log("there is no level panel");

//        // Find all level buttons and add on click event
//        int i = 0;
//        foreach (Transform t in levelPanel)
//        {
//            int currentIndex = i;
//            Button b = t.GetComponent<Button>();
//            b.onClick.AddListener(() => OnLevelselect(currentIndex));

//            i++;
//        }
//    }

//    private void OnLevelselect(int currentIndex)
//    {
//        Debug.Log("Selecting level: " + currentIndex);
//    }

//    /// <summary>
//    /// takes user to level selection menu
//    /// </summary>
//    public void TaskOnLevelSelectionClick()
//    {
//        NavigateTo(1);
//        //SceneManager.LoadScene("LevelSelectionMenu");
//    }

//    ///// <summary>
//    ///// opens settings popup
//    ///// </summary>
//    //void TaskOnSettingsClick()
//    //{
//    //    levelSelection.gameObject.SetActive(false);
//    //    settings.gameObject.SetActive(false);
//    //    settingsPopUp.active = true;
//    //    settingsExit = GameObject.Find("settingsExit").GetComponent<Button>();
//    //}

//    ///// <summary>
//    ///// closes settings popup
//    ///// </summary>
//    //void TaskOnSettingsExitClick()
//    //{
//    //    settingsPopUp.active = false;
//    //    levelSelection.gameObject.SetActive(true);
//    //    settings.gameObject.SetActive(true);
//    //}

//    ///// <summary>
//    ///// opens information popup
//    ///// </summary>
//    //void TaskOnInformationClicl()
//    //{
//    //    if (settingsPopUp.active == true)
//    //        settingsPopUp.active = false;

//    //    levelSelection.gameObject.SetActive(false);
//    //    settings.gameObject.SetActive(false);
//    //    informationPopUp.SetActive(true);
//    //}

//    ///// <summary>
//    ///// closes information popup
//    ///// </summary>
//    //void TaskOnInfromationExitClick()
//    //{
//    //    levelSelection.gameObject.SetActive(true);
//    //    settings.gameObject.SetActive(true);
//    //    informationPopUp.SetActive(false);
//    //}
//}
