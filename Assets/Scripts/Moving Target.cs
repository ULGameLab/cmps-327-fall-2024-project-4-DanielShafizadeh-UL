using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    Vector3 target = new Vector3(0, 0, 0);
    public float moveSp = 6.0f;
    public Vector3 veloc=Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        target=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UpdateTarget();
        }
        SeekTarg();
    }
    void UpdateTarget()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
        {
            UnityEngine.Debug.Log("Hit Point = " + hit.point);
            target = hit.point;
        }
    }
    void SeekTarg()
    {
        Vector3 direction = target - transform.position;

        if (direction.magnitude < 0.005f) direction = Vector3.zero;
        
            Vector3 move = direction.normalized * moveSp ;
        veloc = move;


            transform.position += move*Time.deltaTime;
        
    }
}
