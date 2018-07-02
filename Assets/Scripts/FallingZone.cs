using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FallingPlatform.inZone = true;
        }
    }
}
