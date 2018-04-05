using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour {

    
    private float time;

	// Use this for initialization
	void Start () {
        time = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        LevelScript.energyBarButton.onClick.RemoveAllListeners();
        LevelScript.energyBarButton.onClick.AddListener(TaskOnEnergyBarClick);
        
        if (LevelScript.energyBarTimer.IsActive())
        {
            time -= Time.deltaTime;
            LevelScript.energyBarTimer.value = time;
        }

        //deactivates energy bar
        if (time <= 0f)
        {
            LevelScript.energyBarTimer.gameObject.SetActive(false);
            PlayerMovement.moveSpeedJ = 1.5f;
            PlayerMovement.jumpHeight = 350.0f;
            time = 5.0f;
        }

    }

    /// <summary>
    /// activates energy bar
    /// </summary>
    void TaskOnEnergyBarClick()
    {
        PlayerMovement.moveSpeedJ = 1.0f;
        PlayerMovement.jumpHeight = 400.0f;
        LevelScript.energyBarButton.gameObject.SetActive(false);
        LevelScript.energyBarTimer.gameObject.SetActive(true);
        ClearOutSlot();
    }

    /// <summary>
    /// clears out slot 
    /// </summary>
    void ClearOutSlot()
    {
        if (CharacterScript.energyBar == 1)
            LevelScript.firstSlot = false;
        else if (CharacterScript.energyBar == 2)
            LevelScript.secondSlot = false;
        else if (CharacterScript.energyBar == 3)
            LevelScript.thirdSlot = false;
    }
}
