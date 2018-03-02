using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionMenuScript : MonoBehaviour {

    private Button level_1;

	// Use this for initialization
	void Start () {
        Scene[] scenes = SceneManager.GetAllScenes();
        if (scenes[0].name.Equals("MainMenu"))
            SceneManager.UnloadScene("MainMenu");

        level_1 = GameObject.Find("Level1").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
