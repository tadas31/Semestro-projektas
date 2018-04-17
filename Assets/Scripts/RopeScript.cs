using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{

    public GameObject Node;
    public int length;
    public float nodeLength;
    Rigidbody2D rdbd;
    GameObject lastNode;
    float velocaty = 10;
    HingeJoint2D hinge;
    float force = 2;
    bool foward = true;
    bool movingDown = true;

    //All components for the line to render
    LineRenderer lr;
    List<GameObject> nodes = new List<GameObject>();
    int vertexCount = 1;

    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        for (int i = 1; i <= length; i++)
        {
            GameObject now = Instantiate(Node, new Vector3(transform.position.x, transform.position.y - nodeLength * i, 1f), Quaternion.identity);
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
            nodes.Add(now);
            vertexCount++;
            rdbd = lastNode.GetComponent<Rigidbody2D>();
            rdbd.AddForce(new Vector2(10,0));

        }
        hinge = GetComponent<HingeJoint2D>();
        //InvokeRepeating("ChangeDirection", 4f, 5f);
        Debug.Log(hinge.limits.max);
    }
    // Update is called once per frame
    void Update()
    {
        //rdbd.AddForce(new Vector2(1,0.1f));
        Swinging();
        LineUpdate();
    }

    void LineUpdate()
    {
        lr.SetVertexCount(vertexCount);
        lr.SetPosition(0,transform.position);
        for (int i = 0; i < nodes.Count; i++)
        {
            lr.SetPosition (i+1, nodes[i].transform.position);
        }
    }

    private void Swinging()
    {
        if (movingDown)
        {
            rdbd.AddForce(new Vector2(force, -0.5f));
        }

        if (hinge.limits.min >= hinge.jointAngle && foward)
        {
            foward = false;
            force = -force;
            movingDown = true;
        }
        if (hinge.limits.max <= hinge.jointAngle && !foward)
        {
            foward = true;
            force = -force;
            movingDown = true;
        }
        if (Time.time > 3)
        {
            if (transform.position.x <= rdbd.position.x && foward && movingDown)
            {
                movingDown = false;
            }

            if (transform.position.x >= rdbd.position.x && !foward && movingDown)
                movingDown = false;
        }
    }

}
