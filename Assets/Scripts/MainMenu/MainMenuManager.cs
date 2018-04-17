using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour {

    //fade
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 2.0f;

    //level selection
    public Transform levelPanel;
    public RectTransform menuContainer;

    //position
    private Vector2 desiredMenuPosition;

    void Start()
    {


        //fade
        fadeGroup = FindObjectOfType<CanvasGroup>();
        fadeGroup.alpha = 1;

        //Camera position on menu
        SetCameraTo(LevelManager.Instance.menuFocus);

        // Add buttons on click event to levels
        InitLevel();
    }

    // Update is called once per frame
    void Update()
    {
        //fade in
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
        // Menu navigation
        menuContainer.anchoredPosition = Vector2.Lerp(menuContainer.anchoredPosition, desiredMenuPosition, 0.1f);

    }

    private void SetCameraTo(int menuIndex)
    {
        NavigateTo(menuIndex);
        menuContainer.anchoredPosition = desiredMenuPosition;
    }


    /// <summary>
    /// navigates to desired menu
    /// </summary>
    /// <param name="manuIndex"></param>
    private void NavigateTo(int manuIndex)
    {
        switch (manuIndex)
        {
            // 0 = Mani menu
            default:
            case 0:
                desiredMenuPosition = Vector2.zero;
                break;
            // 1 = level selection menu
            case 1:
                desiredMenuPosition = Vector2.right * -1920;
                break;
        }
    }

    /// <summary>
    /// goes back to main menu
    /// </summary>
    public void TaskOnBackClick()
    {
        NavigateTo(0);
    }

    /// <summary>
    /// adds listenes to all levels
    /// </summary>
    private void InitLevel()
    {

        // Find all level buttons and add on click event
        int i = 0;
        foreach (Transform t in levelPanel)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnLevelselect(currentIndex));

            Image img = t.GetComponent<Image>();

            // is it unlocked
            
            if (i <= SaveManager.Instance.state.completedLevels)
            {
                img.color = Color.white;
            }

            else
            {
                // level isint unlocked disable the button
                b.interactable = false;

                img.color = Color.gray;

            }

            i++;
        }
    }

    /// <summary>
    /// goes in to the leves
    /// </summary>
    /// <param name="currentIndex"></param>
    private void OnLevelselect(int currentIndex)
    {
        LevelManager.Instance.currentLevel = currentIndex;
        SceneManager.LoadScene(currentIndex.ToString());
    }

    /// <summary>
    /// takes user to level selection menu
    /// </summary>
    public void TaskOnLevelSelectionClick()
    {
        NavigateTo(1);
    }
}
