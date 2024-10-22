using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform seekTarget;
    public float speed = 5.0f;
    private float minDist = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SeekTarget();
    }
    void SeekTarget()
    {
        Vector3 direction= seekTarget.position-transform.position;

        if (direction.magnitude > minDist)
        {
            Vector3 move= direction.normalized*speed*Time.deltaTime;

            transform.position+=move;
        }
    }
}
