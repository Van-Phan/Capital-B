using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject target;
    private float xVel;
    private float zVel;
    // Start is called before the first frame update
    void Start()
    {
        xVel = 0;
        zVel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        xVel = target.transform.position.x - rb.position.x;
        zVel = target.transform.position.z - rb.position.z;

        if(xVel > 2)
        {
            xVel = 2;
        }

        if(zVel > 2)
        {
            zVel = 2;
        }

        rb.velocity = new Vector3(xVel, rb.velocity.y, zVel);

        float rotation = Mathf.Atan2(xVel, zVel) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }
}
