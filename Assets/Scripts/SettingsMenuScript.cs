using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Scene[] scenes = SceneManager.GetAllScenes();
        if (scenes[0].name.Equals("MainMenu"))
            SceneManager.UnloadScene("MainMenu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
