using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private Vector3 startPos;

    void Start()
    {
        offset = transform.position - player.transform.position; // tarpas tarp kameros ir zaidejo
        startPos = transform.position;                           // pradine kameros pozicija
        transform.position = transform.position + new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update () {       
        transform.position = new Vector3(player.transform.position.x + offset.x, startPos.y, startPos.z); 
    }
}
