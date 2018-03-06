using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Scene[] scenes = SceneManager.GetAllScenes();
        if (scenes[0].name.Equals("LevelSelectionMenu"))
            SceneManager.UnloadScene("LevelSelectionMenu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
