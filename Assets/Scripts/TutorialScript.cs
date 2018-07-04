using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    //kad galeciau stabdyt platformas pakeist level skripte esanti boola canstopplatform i true

    public static bool wasCameraMoved;              //true if camera was moved else false
    public static bool wasFallingSpikesRemoved;     //true if spikes was removed else false
    private Text cameraMovementText;                //camera movement text
    private Text fallingSpikesText;                 //falling spikes text
    private Text movingPlatformsText;               //moving platforms text
    private Text doneText;                          //done button text


    // Use this for initialization
    void Start () {
        wasCameraMoved = false;
        wasFallingSpikesRemoved = false;

        //gets all tutorial text fields
        cameraMovementText = GameObject.Find("CameraMovementText").GetComponent<Text>();
        fallingSpikesText = GameObject.Find("FallingSpikesText").GetComponent<Text>();
        movingPlatformsText = GameObject.Find("MovingPlatformsText").GetComponent<Text>();
        doneText = GameObject.Find("DoneText").GetComponent<Text>();

        //makes tutorial text fields inactive
        fallingSpikesText.gameObject.SetActive(false);
        movingPlatformsText.gameObject.SetActive(false);
        doneText.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (wasCameraMoved && cameraMovementText.IsActive())
        {
            StartCoroutine(changeCameraMovemenText());
        }
        else if (!cameraMovementText.IsActive() && fallingSpikesText.IsActive())
        {
            if (wasFallingSpikesRemoved)
            {
                fallingSpikesText.gameObject.SetActive(false);
                LevelScript.canStopPlatforms = true;
                movingPlatformsText.gameObject.SetActive(true);
            }
        }
        else if (!fallingSpikesText.IsActive() && movingPlatformsText.IsActive())
        {
            if (PlatformScript.stoppedCount == PlatformScript.stoppableCount)
            {
                movingPlatformsText.gameObject.SetActive(false);
                doneText.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator changeCameraMovemenText()
    {
        yield return new WaitForSeconds(1.0f);
        cameraMovementText.gameObject.SetActive(false);
        fallingSpikesText.gameObject.SetActive(true);
    }
}
