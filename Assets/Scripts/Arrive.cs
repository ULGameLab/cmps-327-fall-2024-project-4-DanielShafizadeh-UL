using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    public Transform arrTarget;
    public float moveSp = 6.0f;
    public float minDist = 0.05f;
    private float speedF = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ArriveTarget();
    }
    void ArriveTarget()
    {
        float dist = Vector3.Distance(arrTarget.position,transform.position);
        if (dist > 10.0f) speedF = 1.0f;
        else if (dist < 3.0f) speedF = 5.0f;
           else speedF = 3.0f;

        Vector3 direction = arrTarget.position - transform.position;
        if(direction.magnitude> minDist)
        {
            Vector3 moveVec=(direction.normalized*moveSp*Time.deltaTime)/speedF;

            transform.position += moveVec;
        }
    }
}
