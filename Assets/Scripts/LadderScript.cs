using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour {

    public BoxCollider2D box;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }
    public void CanGoThrow()
    {
        box.isTrigger = true;
    }
    public void CannotGoThrow()
    {
        box.isTrigger = false;
    }
}
