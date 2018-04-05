using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour {

    public CannonAI cannonAI;

	// Use this for initialization
	void Start () {
        cannonAI = gameObject.GetComponentInParent<CannonAI>();
    }	

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && LevelScript.canMove)       
            cannonAI.Attack();
    }
}
