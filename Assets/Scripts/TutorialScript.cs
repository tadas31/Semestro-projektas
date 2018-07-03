using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    //kad galeciau stabdyt platformas pakeist level skripte esanti boola canstopplatform i true

    public static bool wasCameraMoved;              //true if camera was moved else false
    private Text cameraMovementText;                //camera movement text
    private Text fallingSpikesText;                 //falling spikes text


    // Use this for initialization
    void Start () {
        cameraMovementText = GameObject.Find("CameraMovementText").GetComponent<Text>();
        wasCameraMoved = false;
        fallingSpikesText = GameObject.Find("FallingSpikesText").GetComponent<Text>();
        fallingSpikesText.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (wasCameraMoved && cameraMovementText.IsActive())
        {
            StartCoroutine(changeCameraMovemenText());
        }
        else if (!cameraMovementText.IsActive() && fallingSpikesText.IsActive())
        {
        }
    }

    IEnumerator changeCameraMovemenText()
    {
        yield return new WaitForSeconds(1.0f);
        cameraMovementText.gameObject.SetActive(false);
        fallingSpikesText.gameObject.SetActive(true);
    }
}
