using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {

    private Button restart;
    private string active;
    // Use this for initialization
    void Start () {
        restart = GameObject.Find("Restart").GetComponent<Button>();


    }
	
	// Update is called once per frame
	void Update () {
        restart.onClick.RemoveAllListeners();
        restart.onClick.AddListener(TaskOnRestartClick);
    }

    void TaskOnRestartClick()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
