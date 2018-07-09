using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckPointCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            TutorialScript.checkPointTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            TutorialScript.checkPointTrigger = false;
    }
}
