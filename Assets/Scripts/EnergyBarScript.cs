using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour {

    private Slider timer;
    private float time;

	// Use this for initialization
	void Start () {
        time = 5.0f;
        timer = GameObject.Find("Time").GetComponent<Slider>();
        timer.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        LevelScript.energyBar.onClick.RemoveAllListeners();
        LevelScript.energyBar.onClick.AddListener(TaskOnEnergyBarClick);
        
        if (timer.IsActive())
        {
            time -= Time.deltaTime;
            timer.value = time;
        }

        if (time <= 0f)
        {
            timer.gameObject.SetActive(false);
            PlayerMovement.moveSpeedJ = 1.5f;
            PlayerMovement.jumpHeight = 300.0f;
        }

    }

    void TaskOnEnergyBarClick()
    {
        PlayerMovement.moveSpeedJ = 1.0f;
        PlayerMovement.jumpHeight = 400.0f;
        LevelScript.energyBar.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
    }

    
}
