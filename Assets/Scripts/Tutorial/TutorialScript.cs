using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    private float timer;

    public static bool wasCameraMoved;              //true if camera was moved else false
    public static bool wasFallingSpikesRemoved;     //true if spikes was removed else false
    public static bool enemyTrigger;                //enemy tutorial trigger
    public static bool checkPointTrigger;           //check point tutorial trigger

    private Text cameraMovementText;                //camera movement text
    private Text fallingSpikesText;                 //falling spikes text
    private Text movingPlatformsText;               //moving platforms text
    private Text doneText;                          //done button text
    private Text characterMovementText;             //character movement text
    private Text enemyText;                         //enemy text
    private Text checkPointText;                    //check point text


    // Use this for initialization
    void Start()
    {
        timer = 0;

        wasCameraMoved = false;
        wasFallingSpikesRemoved = false;

        //gets all tutorial text fields
        cameraMovementText = GameObject.Find("CameraMovementText").GetComponent<Text>();
        fallingSpikesText = GameObject.Find("FallingSpikesText").GetComponent<Text>();
        movingPlatformsText = GameObject.Find("MovingPlatformsText").GetComponent<Text>();
        doneText = GameObject.Find("DoneText").GetComponent<Text>();
        characterMovementText = GameObject.Find("CharacterMovementText").GetComponent<Text>();
        enemyText = GameObject.Find("EnemyText").GetComponent<Text>();
        checkPointText = GameObject.Find("CheckPointText").GetComponent<Text>();

        //makes tutorial text fields inactive
        fallingSpikesText.gameObject.SetActive(false);
        movingPlatformsText.gameObject.SetActive(false);
        doneText.gameObject.SetActive(false);
        characterMovementText.gameObject.SetActive(false);
        enemyText.gameObject.SetActive(false);
        checkPointText.gameObject.SetActive(false);

        //tutorial triggers for second phase of game
        enemyTrigger = false;
        checkPointTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        // camera movement tutorial
        CameraMovementTutorial();

        //falling spikes tutorial
        FallingSpikesTutorial();

        //moving platforms tutorial
        MovingPlatformsTutorial();

        //done tutorial
        DoneTutorial();

        //player movement tutorial
        PlayerMovementTutorial();

        //enemy tutorial
        TriggerTutorials(enemyTrigger, enemyText);

        //check point tutorial
        TriggerTutorials(checkPointTrigger, checkPointText);


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

    /// <summary>
    /// camera movement tutorial
    /// </summary>
    private void CameraMovementTutorial()
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
    }
    
    /// <summary>
    /// falling spikes tutorial
    /// </summary>
    private void FallingSpikesTutorial()
    {
        if (!cameraMovementText.IsActive() && fallingSpikesText.IsActive())
        {
            if (wasFallingSpikesRemoved)
            {

                StartCoroutine(DelayHalfS(fallingSpikesText, movingPlatformsText));
            }
        }
    }

    /// <summary>
    /// moving platforms tutorial
    /// </summary>
    private void MovingPlatformsTutorial()
    {
         if (!fallingSpikesText.IsActive() && movingPlatformsText.IsActive())
        {
            LevelScript.canStopPlatforms = true;
            if (PlatformScript.stoppedCount == PlatformScript.stoppableCount)
            {
                movingPlatformsText.gameObject.SetActive(false);
                doneText.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// done tutorial
    /// </summary>
    private void DoneTutorial()
    {
        if (!movingPlatformsText.IsActive() && doneText.IsActive())
        {
            if (!cameraMovement.moveCamera)
            {
                doneText.gameObject.SetActive(false);
                characterMovementText.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// player movement tutorial
    /// </summary>
    private void PlayerMovementTutorial()
    {
        if (!doneText.IsActive() && characterMovementText.IsActive())
        {
            if (checkPointTrigger)
                characterMovementText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// tutorials that show up after hiting triger
    /// </summary>
    /// <param name="triger"></param>
    /// <param name="tutorialText"></param>
    private void TriggerTutorials(bool triger, Text tutorialText)
    {
        if (triger)
            tutorialText.gameObject.SetActive(true);
        else
            tutorialText.gameObject.SetActive(false);
    }
}
