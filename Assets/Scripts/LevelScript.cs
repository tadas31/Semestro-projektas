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

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;

        restart = GameObject.Find("Restart").GetComponent<Button>();

        pause = GameObject.Find("Pause").GetComponent<Button>();
        pausePopup = GameObject.Find("PausePopup");
        pausePopup.SetActive(false);
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
}
