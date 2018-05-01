using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour {

    
    private float time;

    private float boostedJump = 420.0f;
    private float boostedSpeed = 0.8f;

	// Use this for initialization
	void Start () {
        time = SaveManager.Instance.ReturnBoostsDuration()[1];
        LevelScript.energyBarTimer.maxValue = time;

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
            PlayerMovement.moveSpeedJ = SaveManager.Instance.ReturnCharacterStats()[1];
            PlayerMovement.jumpHeight = SaveManager.Instance.ReturnCharacterStats()[0];
            time = SaveManager.Instance.ReturnBoostsDuration()[1];
        }

    }

    /// <summary>
    /// activates energy bar
    /// </summary>
    void TaskOnEnergyBarClick()
    {
        PlayerMovement.moveSpeedJ = boostedSpeed;
        PlayerMovement.jumpHeight = boostedJump;
        LevelScript.energyBarButton.gameObject.SetActive(false);
        LevelScript.energyBarTimer.gameObject.SetActive(true);
        ClearOutSlot();
        FindObjectOfType<AudioManager>().Play("Use_boost");
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
