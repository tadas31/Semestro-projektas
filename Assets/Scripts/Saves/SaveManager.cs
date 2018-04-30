using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(SaveHelper.Serialize<SaveState>(state));
    }

    // Save the whole state of this saveState script to the player pref
    public void Save()
    {
        PlayerPrefs.SetString("save", SaveHelper.Serialize<SaveState>(state));
    }

    // Load the previous saved state from the player prefs
    public void Load()
    {
        // Was it saved
        if (PlayerPrefs.HasKey("save"))
        {
            state = SaveHelper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No saves");
        }
    }

    // Reset save file
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }

    // Add candy
    public void AddCandy(int candy)
    {
        state.candy += candy;
        Save();
    }

    // Return candy
    public int ReturnCandy()
    {
        return state.candy;
    }

    //Complete level
    public void CompleteLevel(int index)
    {
        if(state.completedLevels == index)
        {
            state.completedLevels++;
            Save();
        }
    }

    // Set mute state
    public void SetMute(bool mute)
    {    
        Debug.Log(mute);
        state.mute = mute;
        Save();
    }

    // Return mute state
    public bool ReturnMute()
    {
        return state.mute;
    }

    /// <summary>
    /// upgrades boost or character
    /// </summary>
    /// <param name="upgradeID">0 - gum, 1 - energy barr, 2 - shield, 3 - jump, 4 - speed, 5 - lives</param>
    /// <param name="upgrade">to what upgrade</param>
    public void AddUpgrade(int upgradeID, int upgrade, float upgradedValue)
    {
        state.upgrades[upgradeID] = upgrade;
        if (upgradeID < 3)
            state.boostsTime[upgradeID] = upgradedValue;
        Save();
    }

    /// <summary>
    /// returns sprites for updates
    /// </summary>
    /// <returns></returns>
    public int[] ReturnUpgrade()
    {
        return state.upgrades;
    }

    public float[] ReturnBoostsDuration()
    {
        return state.boostsTime;
    }

}
