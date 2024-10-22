using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursuit : MonoBehaviour
{
    public Transform target;
    public Transform prediction;
    public float movementSp = 4.0f;
    public float minDistance = 0.05f;
    public float offset=7.0f;
    Vector3 baseVec= new Vector3(1,0,0);
    float lookAheadCounter = 0;
    Vector3 predictedTargetPosition = Vector3.zero;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) transform.position = startPosition;
        if (lookAheadCounter <= 0) UpdatePrediction();
        lookAheadCounter--;
        PursueTargetOff();
    }
    void UpdatePrediction()
    {
        Vector3 targetVelocity = target.GetComponent<MovingTarget>().veloc;
        lookAheadCounter = Math.Max(1, Vector3.Distance(target.transform.position, transform.position) / (movementSp + targetVelocity.magnitude));
        lookAheadCounter = lookAheadCounter / 3;
        predictedTargetPosition = target.position + targetVelocity * lookAheadCounter;
        Vector3 offsetVec=baseVec.normalized*offset;
        predictedTargetPosition += offsetVec;
        prediction.position = predictedTargetPosition;

    }
    void PursueTargetOff()
    {
        Vector3 direction = (predictedTargetPosition) - transform.position;
        if (direction.magnitude > minDistance)
        {
            Vector3 moveVec = direction.normalized * movementSp * Time.deltaTime;
            transform.position += moveVec;
        }
    }
}
