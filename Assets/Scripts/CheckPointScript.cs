using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    bool triggered;
    void Awake()
    {
        triggered = false;
    }
    // called whenever another collider enters our zone (if layers match)
    void OnTriggerEnter2D(Collider2D collider)
    {
        // check we haven't been triggered yet!
        if (!triggered)
        {
            // check we actually collided with 
            // a character. It would be best to
            // setup your layers so this check is
            // not required, by creating a layer 
            // "Checkpoint" that will only collide 
            // with characters.
            if (collider.gameObject.tag
                == "Player")
            {
                Trigger();
            }
        }
    }
    void Trigger()
    {
        // Tell the animation controller about our 
        // recent triggering
        //GetComponent<Animator>().SetTrigger("Triggered");
        LevelScript.SetRespawnPosition(transform.position);
        triggered = true;
    }
}
