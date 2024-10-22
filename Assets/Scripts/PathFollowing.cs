using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    List<Vector3> pathVectors;
    int loop = 0;

    // Start is called before the first frame update
    void Start()
    {
        pathVectors = new List<Vector3>();
        pathVectors.Add(new Vector3(-2.5f, 0.5f, 0.5f));
        pathVectors.Add(new Vector3(-2.5f, 0.5f, -10.0f));
        pathVectors.Add(new Vector3(-15.0f, 0.5f, -10.0f));
        pathVectors.Add(new Vector3(-15.0f, 0.5f, 3.5f));
        pathVectors.Add(new Vector3(-1.25f, 0.5f, 3.5f));
        pathVectors.Add(new Vector3(-1.25f, 0.5f, 10.0f));
        pathVectors.Add(new Vector3(12.0f, 0.5f, 10.0f));
        pathVectors.Add(new Vector3(12.0f, 0.5f, -9.5f));
        pathVectors.Add(new Vector3(0.5f, 0.5f, -9.5f));
        pathVectors.Add(new Vector3(-1.25f, 0.5f, -9.5f));
        pathVectors.Add(new Vector3(-1.25f, 0.5f, -15.0f));
        pathVectors.Add(new Vector3(-2.5f, 0.5f, -9.5f));
    }

    // Update is called once per frame
    void Update()
    {

        
        loopthrough();
    }
    void loopthrough()
    {

        if (loop == pathVectors.Count) {
            loop = 0;
        
        }
        transform.position = pathVectors[loop]-transform.position;

        loop++;
    }

        
    
}
