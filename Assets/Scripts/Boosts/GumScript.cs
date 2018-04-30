using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GumScript : MonoBehaviour
{

    public static bool canFloat;
    public float speed;

    private GameObject gum;

    private float time;

    // Use this for initialization
    void Start()
    {
        time = SaveManager.Instance.ReturnBoostsDuration()[0];
        canFloat = false;
        gum = GameObject.Find("GumBouble");
        gum.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LevelScript.gumButton.onClick.RemoveAllListeners();
        LevelScript.gumButton.onClick.AddListener(TaskOnGumClick);

        if (canFloat)
        {
            time -= Time.deltaTime;
            LevelScript.gumTimer.value = time;
        }

        if (time <= 0f)
        {
            PlayerMovement.rdbd.gravityScale = 1;
            LevelScript.gumTimer.gameObject.SetActive(false);
            gum.SetActive(false);
            canFloat = false;
            time = SaveManager.Instance.ReturnBoostsDuration()[0];
        }
    }

    private void FixedUpdate()
    {
        if (canFloat)
        {
            PlayerMovement.rdbd.velocity += new Vector2(PlayerMovement.dir.x / speed, PlayerMovement.dir.y / speed);
            PlayerMovement.rdbd.drag = 5;
            PlayerMovement.rdbd.gravityScale = 0.2f;
        }
    }

    /// <summary>
    /// allows character to float
    /// </summary>
    void TaskOnGumClick()
    {
        canFloat = true;
        gum.SetActive(true);
        LevelScript.gumButton.gameObject.SetActive(false);
        LevelScript.gumTimer.gameObject.SetActive(true);
        ClearOutSlot();
        FindObjectOfType<AudioManager>().Play("Use_boost");
    }

    /// <summary>
    /// clears out slot 
    /// </summary>
    void ClearOutSlot()
    {
        if (CharacterScript.gum == 1)
            LevelScript.firstSlot = false;
        else if (CharacterScript.gum == 2)
            LevelScript.secondSlot = false;
        else if (CharacterScript.gum == 3)
            LevelScript.thirdSlot = false;
    }
}
