using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAI : MonoBehaviour {

    public int currHealth;
    public int maxHealth;

    public float distance;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public GameObject bullet;
    public Transform target;
    public Transform shootPoint;

    public GameObject trackTarget;
    Vector2 lastKnownPosition = Vector2.zero;
    Quaternion lookAtRotation;
    float rotationSpeed = 10f;

    // Use this for initialization
    void Start () {
        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        RangeCheck();

        Tracking();
    }

    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

    }

    public void Attack()
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            bulletTimer = 0;

        }
    }

    void Tracking()
    {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 180;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
