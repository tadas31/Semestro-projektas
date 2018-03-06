using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuScript : MonoBehaviour {

    private Button back;
    private Button information;
    private GameObject panel;

	// Use this for initialization
	void Start () {
        Scene[] scenes = SceneManager.GetAllScenes();
        if (scenes[0].name.Equals("MainMenu"))
            SceneManager.UnloadScene("MainMenu");

        panel = GameObject.Find("InfoPanel");

        panel.SetActive(false);
        back = GameObject.Find("Back").GetComponent<Button>();
        information = GameObject.Find("Information").GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        back.onClick.RemoveAllListeners();
        back.onClick.AddListener(TaskOnBackClick);

        information.onClick.RemoveAllListeners();
        information.onClick.AddListener(TaskOnBackClic);
        if (panel.active && Input.GetMouseButton(0))
            panel.SetActive(false);

    }

    void TaskOnBackClick()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
    void TaskOnBackClic()
    {
        panel.SetActive(true);
    }
}
