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
    public void AddCandy()
    {
        state.candy++;
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

}
