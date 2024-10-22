

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : MonoBehaviour
{
    public Transform target;
    public Transform prediction;
    public float movementSp = 4.0f;
    public float dist = 15.0f;
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
        EvadeTarget();
    }
    void UpdatePrediction()
    {
        Vector3 targetVelocity = target.GetComponent<MovingTarget>().veloc;
        lookAheadCounter = Math.Max(1, Vector3.Distance(target.transform.position, transform.position) / (movementSp + targetVelocity.magnitude));
        lookAheadCounter = lookAheadCounter / 3;
        predictedTargetPosition = target.position + targetVelocity * lookAheadCounter;
        prediction.position = predictedTargetPosition;
    }
    void EvadeTarget()
    {
        Vector3 direction = predictedTargetPosition - transform.position;
        if (direction.magnitude <dist)
        {
            Vector3 moveVec = direction.normalized * movementSp * Time.deltaTime;
            transform.position -= moveVec;
        }
    }
}

