using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { set; get; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public int currentLevel = 0;    //selected level
    public int menuFocus = 0;       //which menu to focus on
}
