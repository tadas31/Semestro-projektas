using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour {

    public GameObject Node;
    public int length;
    public float nodeLength;
    Rigidbody2D rdbd;
    GameObject lastNode;
    float velocaty = 10;
    HingeJoint2D hinge;
    float force = 3;
    bool foward = true;
    // Use this for initialization
    void Start()
    {
        for (int i = 1; i <= length; i++)
        {
            GameObject now = Instantiate(Node, new Vector2(transform.position.x, transform.position.y - nodeLength * i), Quaternion.identity);
            if (i == 1)
            {
                rdbd = GetComponent<Rigidbody2D>();
                now.GetComponent<HingeJoint2D>().connectedBody = rdbd;
            }
            else
            {
                now.GetComponent<HingeJoint2D>().connectedBody = lastNode.GetComponent<Rigidbody2D>();
            }
            lastNode = now;
            rdbd = lastNode.GetComponent<Rigidbody2D>();
            //rdbd.velocity = new Vector2(velocaty, 0);

        }
        hinge = GetComponent<HingeJoint2D>();
        //InvokeRepeating("ChangeDirection", 4f, 5f);
        Debug.Log(hinge.limits.max);
    }
	// Update is called once per frame
	void Update () {
        //rdbd.AddForce(new Vector2(1,0.1f));
        Swinging();
    }

    private void Swinging()
    {
        rdbd.AddForce(new Vector2(force, -0.5f));
        if (hinge.limits.min >= hinge.jointAngle && foward)
        {
            foward = false;
            force = -force;
        }
        if (hinge.limits.max <= hinge.jointAngle && !foward)
        {
            foward = true;
            force = -force;
        }

    }

}
