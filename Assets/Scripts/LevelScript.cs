using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {
    private static Button restart;

    private static Button pause;
    private GameObject pausePopup;

    private Button home;

    private Button done;

    public cameraMovement camera;

    public static Button jumButton;

    private static GameObject gameOverPopup;
    private static Vector2 startPos;
    private static Button respawn;
    private static Button restartWithText;
    private static Button backToMenuWithText;
    public static bool canMove;


    int MovingCount = 2;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;

        restart = GameObject.Find("Restart").GetComponent<Button>();

        pause = GameObject.Find("Pause").GetComponent<Button>();
        pausePopup = GameObject.Find("PausePopup");
        pausePopup.SetActive(false);

        gameOverPopup = GameObject.Find("GameOverPopup");
        gameOverPopup.SetActive(false);
        startPos = CharacterScript.rdbd.position;
        canMove = true;

        done = GameObject.Find("Done").GetComponent<Button>();

        jumButton = GameObject.Find("Jump").GetComponent<Button>();
        jumButton.gameObject.active = false;
        done.interactable = false;
    }

    // Update is called once per frame
        void Update () {

        restart.onClick.RemoveAllListeners();
        restart.onClick.AddListener(TaskOnRestartClick);

        pause.onClick.RemoveAllListeners();
        pause.onClick.AddListener(TaskOnPauseClick);

        if (pausePopup.active == true)
        {
            home.onClick.RemoveAllListeners();
            home.onClick.AddListener(TaskOnHomeClick);
        }

        done.onClick.RemoveAllListeners();
        done.onClick.AddListener(TaskOnDoneClick);

        if (PlatformScript.stoppedCount == MovingCount && cameraMovement.moveCamera)  // Checks if all the stoppable platforms are stopped
            done.interactable = true;
    }

    /// <summary>
    /// tasks if player dies
    /// </summary>
    public static void OnDeath()
    {
        //sets game over popup active and gets buttons
        restart.interactable = false;
        pause.interactable = false;
        jumButton.interactable = false;
        canMove = false;

        gameOverPopup.SetActive(true);
        respawn = GameObject.Find("Respawn").GetComponent<Button>();
        restartWithText = GameObject.Find("RestartWithText").GetComponent<Button>();
        backToMenuWithText = GameObject.Find("BackToMenuWithText").GetComponent<Button>();

        //restart
        respawn.onClick.RemoveAllListeners();
        respawn.onClick.AddListener(TaskOnRespawnClick);

        restartWithText.onClick.RemoveAllListeners();
        restartWithText.onClick.AddListener(TaskOnRestartClick);

        //back to menu
        backToMenuWithText.onClick.RemoveAllListeners();
        backToMenuWithText.onClick.AddListener(TaskOnBackToMenuWithTextClick);
    }

    /// <summary>
    /// pause game
    /// </summary>
    void TaskOnPauseClick()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausePopup.SetActive(true);
            home = GameObject.Find("Home").GetComponent<Button>();
        }
        else
        {
            pausePopup.SetActive(false);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// takes user to level selection menu
    /// </summary>
    void TaskOnHomeClick()
    {
        SceneManager.LoadScene("LevelSelectionMenu");
    }

    /// <summary>
    /// takes user to second stage of the game
    /// </summary>
    void TaskOnDoneClick()
    {
        if (PlatformScript.stoppedCount == MovingCount)  // Checks if all the stoppable platforms are stopped
        {
            cameraMovement.moveCamera = false;
            done.gameObject.active = false;
            jumButton.gameObject.active = true;
        }
    }

    /// <summary>
    /// respawns player at the starting position
    /// </summary>
    static void TaskOnRespawnClick()
    {
        CharacterScript.rdbd.transform.position = startPos;
        CharacterScript.lives = 3;
        gameOverPopup.SetActive(false);
        restart.interactable = true;
        pause.interactable = true;
        jumButton.interactable = true;
        canMove = true;
    }

    /// <summary>
    /// takes user to main menu
    /// </summary>
    static void TaskOnBackToMenuWithTextClick()
    {
        Application.LoadLevel("MainMenu");
    }

    /// <summary>
    /// restarts level
    /// </summary>
    static void TaskOnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
