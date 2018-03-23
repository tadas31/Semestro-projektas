using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {
    private Button restart;

    private Button pause;
    private GameObject pausePopup;

    private Button home;

    private Button done;

    public cameraMovement camera;

    public GameObject jumButton;


    int MovingCount = 2;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;

        restart = GameObject.Find("Restart").GetComponent<Button>();

        pause = GameObject.Find("Pause").GetComponent<Button>();
        pausePopup = GameObject.Find("PausePopup");
        pausePopup.SetActive(false);

        done = GameObject.Find("Done").GetComponent<Button>();

        jumButton = GameObject.Find("Jump");
        
        jumButton.active = false;
        done.gameObject.active = false;
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
            done.gameObject.active = true;



    }

    void TaskOnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

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

    void TaskOnHomeClick()
    {
        SceneManager.LoadScene("LevelSelectionMenu");
    }

    void TaskOnDoneClick()
    {
        if (PlatformScript.stoppedCount == MovingCount)  // Checks if all the stoppable platforms are stopped
        {
            cameraMovement.moveCamera = false;
            done.gameObject.active = false;
            jumButton.active = true;
        }


    }
}
