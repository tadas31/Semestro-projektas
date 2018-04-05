using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    private GameObject shield;

    private float time;

    // Use this for initialization
    void Start () {
        time = 10.0f;
        shield = GameObject.Find("ShieldBuoble");
        shield.SetActive(false);
        LevelScript.shieldTimer.gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {

        time -= Time.deltaTime;
        LevelScript.shieldTimer.value = time;

    }
}
