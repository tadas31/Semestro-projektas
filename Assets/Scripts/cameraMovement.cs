using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if(player.transform.position.x > -18)
            transform.position = new Vector3(player.transform.position.x,1,-10);
	}
}
