using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {


    GameObject Finish;
	// Use this for initialization
	void Start () {
        Finish = GameObject.Find("GameOverPopup");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelScript.OnFinish();
            FindObjectOfType<AudioManager>().Play("Win");
        }
    }
}
