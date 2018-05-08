using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {
    private float time;

    //respawn in game button
    private static Button respawnInGame;

    //pause
    private static Button pause;
    private GameObject pausePopup;

    //home
    private Button home;

    //done
    private Button done;

    //camera
    public cameraMovement camera;

    //jump
    public static Button jumButton;

    //game over
    private static GameObject gameOverPopup;
    private static Vector2 startPos;
    private static Button respawn;
    private static Button restartWithText;
    private static Button backToMenuWithText;
    public static bool canMove;

    //finish
    private static GameObject finishPopup;
    private static Button nextLevel;

    //energy bar
    public static Button energyBarButton;
    public static Slider energyBarTimer;

    //gum
    public static Button gumButton;
    public static Slider gumTimer;

    //shield
    public static Button shieldButton;
    public static Slider shieldTimer;

    //inventory
    public static bool firstSlot;
    public static bool secondSlot;
    public static bool thirdSlot;
    public static GameObject pos1;
    public static GameObject pos2;
    public static GameObject pos3;

    // Use this for initialization
    void Start () {
        //restart
        respawnInGame = GameObject.Find("RespawnInGame").GetComponent<Button>();

        //done
        done = GameObject.Find("Done").GetComponent<Button>();
        done.interactable = false;

        //finish
        finishPopup = GameObject.Find("FinishPopup");
        finishPopup.gameObject.SetActive(false);

        //pause
        pause = GameObject.Find("Pause").GetComponent<Button>();
        pausePopup = GameObject.Find("PausePopup");
        pausePopup.SetActive(false);
        Time.timeScale = 1;

        //game over
        gameOverPopup = GameObject.Find("GameOverPopup");
        gameOverPopup.SetActive(false);
        canMove = true;
        startPos = GameObject.Find("player").transform.position;

        //jump
        jumButton = GameObject.Find("Jump").GetComponent<Button>();
        jumButton.gameObject.SetActive(false);


        //energy bar
        energyBarButton = GameObject.Find("EnergyBarButton").GetComponent<Button>();
        energyBarTimer = GameObject.Find("EnergyBarTime").GetComponent<Slider>();
        energyBarButton.gameObject.SetActive(false);
        time = SaveManager.Instance.ReturnBoostsDuration()[1];
        energyBarTimer.maxValue = time;
        energyBarTimer.gameObject.SetActive(false);

        //gum
        gumButton = GameObject.Find("GumButton").GetComponent<Button>();
        gumTimer = GameObject.Find("GumTime").GetComponent<Slider>();
        gumButton.gameObject.SetActive(false);
        time = SaveManager.Instance.ReturnBoostsDuration()[0];
        gumTimer.maxValue = time;
        gumTimer.gameObject.SetActive(false);

        //shield
        shieldButton = GameObject.Find("ShieldButton").GetComponent<Button>();
        shieldTimer = GameObject.Find("ShieldTime").GetComponent<Slider>();
        shieldButton.gameObject.SetActive(false);
        time = SaveManager.Instance.ReturnBoostsDuration()[2];
        shieldTimer.maxValue = time;
        shieldTimer.gameObject.SetActive(false);

        //inventory
        firstSlot = false;
        secondSlot = false;
        thirdSlot = false;
        pos1 = GameObject.Find("pos1");
        pos2 = GameObject.Find("pos2");
        pos3 = GameObject.Find("pos3");
        pos1.SetActive(false);
        pos2.SetActive(false);
        pos3.SetActive(false);
    }

    // Update is called once per frame
        void Update () {

        respawnInGame.onClick.RemoveAllListeners();
        respawnInGame.onClick.AddListener(TaskOnRespawnClick);

        pause.onClick.RemoveAllListeners();
        pause.onClick.AddListener(TaskOnPauseClick);

        if (pausePopup.active == true)
        {
            home.onClick.RemoveAllListeners();
            home.onClick.AddListener(TaskOnHomeClick);
        }

        done.onClick.RemoveAllListeners();
        done.onClick.AddListener(TaskOnDoneClick);

        if (PlatformScript.stoppedCount == PlatformScript.stoppableCount && cameraMovement.moveCamera)  // Checks if all the stoppable platforms are stopped
            done.interactable = true;
    }

    /// <summary>
    /// tasks if player dies
    /// </summary>
    public static void OnDeath()
    {
        if (finishPopup.active = false)
        {
            //sets game over popup active and gets buttons
            respawnInGame.interactable = false;
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
            FindObjectOfType<AudioManager>().Play("Death");
        }
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
        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// takes user to level selection menu
    /// </summary>
    void TaskOnHomeClick()
    {
        LevelManager.Instance.menuFocus = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// takes user to second stage of the game
    /// </summary>
    void TaskOnDoneClick()
    {
        if (PlatformScript.stoppedCount == PlatformScript.stoppableCount)  // Checks if all the stoppable platforms are stopped
        {
            cameraMovement.moveCamera = false;
            done.gameObject.SetActive(false);
            jumButton.gameObject.SetActive(true);
        }
        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// respawns player at the starting position
    /// </summary>
    static void TaskOnRespawnClick()
    {
        CharacterScript.rdbd.transform.position = startPos;
        CharacterScript.lives = SaveManager.Instance.ReturnCharacterStats()[2];
        gameOverPopup.SetActive(false);
        respawnInGame.interactable = true;
        pause.interactable = true;
        jumButton.interactable = true;
        canMove = true;
        BubblePlatform.active = true;
        BubblePlatform.isPoped = false;
        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// takes user to main menu
    /// </summary>
    static void TaskOnBackToMenuWithTextClick()
    {
        LevelManager.Instance.menuFocus = 1;

        finishPopup.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// restarts level
    /// </summary>
    static void TaskOnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// takes user to next level
    /// </summary>
    static void TaskOnNextLevelClick()
    {
        LevelManager.Instance.currentLevel++;
        SceneManager.LoadScene(LevelManager.Instance.currentLevel.ToString());
        FindObjectOfType<AudioManager>().Play("Button_press");
    }

    /// <summary>
    /// Tasks if player finishes
    /// </summary>
    public static void OnFinish()
    {
        //adds colected candy to owned candy
        

        SaveManager.Instance.AddCandy(CharacterScript.getCandyCount());

        SaveManager.Instance.CompleteLevel(LevelManager.Instance.currentLevel);


        finishPopup.gameObject.SetActive(true);
        backToMenuWithText = GameObject.Find("BackToMenuWithText").GetComponent<Button>();
        nextLevel = GameObject.Find("NextLevel").GetComponent<Button>();
        respawnInGame.interactable = false;
        pause.interactable = false;
        jumButton.interactable = false;
        canMove = false;

        //back to menu
        backToMenuWithText.onClick.RemoveAllListeners();
        backToMenuWithText.onClick.AddListener(TaskOnBackToMenuWithTextClick);

        nextLevel.onClick.RemoveAllListeners();
        nextLevel.onClick.AddListener(TaskOnNextLevelClick);
    }

    public static void Position(out Vector2 pos, out int slot)
    {
        pos = Vector2.zero;
        slot = 0;
        if (!firstSlot)
        {
            firstSlot = true;
            pos = pos1.transform.position;
            slot = 1;
        }
        else if (!secondSlot)
        {
            secondSlot = true;
            pos = pos2.transform.position;
            slot = 2;
        }
        else if (!thirdSlot)
        {
            thirdSlot = true;
            pos = pos3.transform.position;
            slot = 3;
        }
    }


    /// <summary>
    /// Set the position of the respawn to the position of the vector
    /// </summary>
    /// <param name="set">Position</param>
    public static void SetRespawnPosition(Vector2 set)
    {
        startPos = set;
    }

}
