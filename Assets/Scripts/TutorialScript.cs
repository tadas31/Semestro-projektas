using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    private Vector3 characterStartingPosition = new Vector3(-3.891f, 1.03443f, 0);  //character starting position
    private float timer;

    public static bool wasCameraMoved;              //true if camera was moved else false
    public static bool wasFallingSpikesRemoved;     //true if spikes was removed else false
    private bool jump;                              //true if jumped else false
    private Text cameraMovementText;                //camera movement text
    private Text fallingSpikesText;                 //falling spikes text
    private Text movingPlatformsText;               //moving platforms text
    private Text doneText;                          //done button text
    private Text characterMovementText;             //character movement text
    private Text enemyText;                         //enemy text


    // Use this for initialization
    void Start()
    {
        timer = 0;

        wasCameraMoved = false;
        wasFallingSpikesRemoved = false;
        jump = false;

        //gets all tutorial text fields
        cameraMovementText = GameObject.Find("CameraMovementText").GetComponent<Text>();
        fallingSpikesText = GameObject.Find("FallingSpikesText").GetComponent<Text>();
        movingPlatformsText = GameObject.Find("MovingPlatformsText").GetComponent<Text>();
        doneText = GameObject.Find("DoneText").GetComponent<Text>();
        characterMovementText = GameObject.Find("CharacterMovementText").GetComponent<Text>();
        enemyText = GameObject.Find("EnemyText").GetComponent<Text>();

        //makes tutorial text fields inactive
        fallingSpikesText.gameObject.SetActive(false);
        movingPlatformsText.gameObject.SetActive(false);
        doneText.gameObject.SetActive(false);
        characterMovementText.gameObject.SetActive(false);
        enemyText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (wasCameraMoved && cameraMovementText.IsActive())
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                cameraMovementText.gameObject.SetActive(false);
                fallingSpikesText.gameObject.SetActive(true);
            }
            if (wasFallingSpikesRemoved)
            {
                cameraMovementText.gameObject.SetActive(false);
                movingPlatformsText.gameObject.SetActive(true);
            }
        }

        else if (!cameraMovementText.IsActive() && fallingSpikesText.IsActive())
        {
            if (wasFallingSpikesRemoved)
            {
               
                StartCoroutine(DelayHalfS(fallingSpikesText, movingPlatformsText));
            }
        }

        else if (!fallingSpikesText.IsActive() && movingPlatformsText.IsActive())
        {
            LevelScript.canStopPlatforms = true;
            if (PlatformScript.stoppedCount == PlatformScript.stoppableCount)
            {
                movingPlatformsText.gameObject.SetActive(false);
                doneText.gameObject.SetActive(true);
            }
        }

        else if (!movingPlatformsText.IsActive() && doneText.IsActive())
        {
            if (!cameraMovement.moveCamera)
            {
                doneText.gameObject.SetActive(false);
                characterMovementText.gameObject.SetActive(true);
            }
        }

        else if (!doneText.IsActive() && characterMovementText.IsActive())
        {
            if (CharacterScript.rdbd.position.y > characterStartingPosition.y)
                jump = true;

            if (CharacterScript.rdbd.position.x != characterStartingPosition.x && jump)
            {
                StartCoroutine(DelayOneS(characterMovementText, enemyText));
               
            }
        }
    }

    IEnumerator DelayOneS(Text disable, Text enable)
    {
        yield return new WaitForSeconds(1.0f);
        disable.gameObject.SetActive(false);
        enable.gameObject.SetActive(true);
        
    }

    IEnumerator DelayHalfS(Text disable, Text enable)
    {
        yield return new WaitForSeconds(0.5f);
        disable.gameObject.SetActive(false);
        enable.gameObject.SetActive(true);
    }
}
