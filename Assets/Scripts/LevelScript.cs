using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {
    private float time;

    //bubble platforms
    static GameObject[] BubblePlatforms;

    //respawn in game button
    private static Button respawnInGame;

    //pause
    private static Button pause;
    private static Button unpause;
    private static GameObject pausePopup;

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
    void Start() {
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
    void Update() {

        //respawn
        respawnInGame.onClick.RemoveAllListeners();
        respawnInGame.onClick.AddListener(TaskOnRespawnClick);

        //pause
        pause.onClick.RemoveAllListeners();
        pause.onClick.AddListener(OnPause);

        //done stoping platforms
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
        //if (finishPopup.active = false)
        //{
            //sets game over popup active and gets buttons
            respawnInGame.interactable = false;
            pause.interactable = false;
            jumButton.interactable = false;
            canMove = false;

            gameOverPopup.SetActive(true);
            respawn = GameObject.Find("Respawn").GetComponent<Button>();
            restartWithText = GameObject.Find("RestartWithText").GetComponent<Button>();
            backToMenuWithText = GameObject.Find("BackToMenuWithText").GetComponent<Button>();

            //respawn
            respawn.onClick.RemoveAllListeners();
            respawn.onClick.AddListener(TaskOnRespawnClick);
            
            //restart
            restartWithText.onClick.RemoveAllListeners();
            restartWithText.onClick.AddListener(TaskOnRestartClick);

            //back to menu
            backToMenuWithText.onClick.RemoveAllListeners();
            backToMenuWithText.onClick.AddListener(TaskOnBackToMenuWithTextClick);
            FindObjectOfType<AudioManager>().Play("Death");
        //}
    }

    /// <summary>
    /// pause menu
    /// </summary>
    void OnPause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausePopup.SetActive(true);
            respawnInGame.interactable = false;
            canMove = false;
            

            respawn = GameObject.Find("Respawn").GetComponent<Button>();
            restartWithText = GameObject.Find("RestartWithText").GetComponent<Button>();
            backToMenuWithText = GameObject.Find("BackToMenuWithText").GetComponent<Button>();
            unpause = GameObject.Find("Unpause").GetComponent<Button>();

            //back to menu
            backToMenuWithText.onClick.RemoveAllListeners();
            backToMenuWithText.onClick.AddListener(TaskOnHomeClick);

            //restart level
            restartWithText.onClick.RemoveAllListeners();
            restartWithText.onClick.AddListener(TaskOnRestartClick);

            //respawn
            respawn.onClick.RemoveAllListeners();
            respawn.onClick.AddListener(TaskOnRespawnClick);

            //unpause
            unpause.onClick.RemoveAllListeners();
            unpause.onClick.AddListener(TaskOnUnpauseClick);
        }

        else
        {
            respawnInGame.interactable = true;
            canMove = true;
            pausePopup.SetActive(false);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// unpauses game
    /// </summary>
    void TaskOnUnpauseClick()
    {
        respawnInGame.interactable = true;
        canMove = true;
        pausePopup.SetActive(false);
        Time.timeScale = 1;
    }


    /// <summary>
    /// takes user to level selection menu
    /// </summary>
    void TaskOnHomeClick()
    {
        LevelManager.Instance.menuFocus = 1;
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
        
        respawnInGame.interactable = true;
        pause.interactable = true;
        jumButton.interactable = true;
        canMove = true;
        FindObjectOfType<AudioManager>().Play("Button_press");

        if (pausePopup.active == true)
        {
            Time.timeScale = 1;
            pausePopup.SetActive(false);
        }

        if (gameOverPopup.active == true)
            gameOverPopup.SetActive(false);

        Debug.Log("wtfffff   " + BubblePlatform.isPoped);
        if (BubblePlatform.isPoped)
        {
            
            BubblePlatforms = GameObject.FindGameObjectsWithTag("BubblePlatform");
            Debug.Log("wtfffff  " + BubblePlatforms.Length);
            for (int i = 0; i < BubblePlatforms.Length; i++)
            {
                BubblePlatforms[i].GetComponent<Animator>().Play("BubblePlatform_Idle");
                BubblePlatforms[i].GetComponent<Collider2D>().enabled = true;
            }
                
                

        }
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
    public void RemoveButton()
    {
        Debug.Log("Paspaudei");
        GameObject.Find("Introduction").SetActive(false);
    }
}
