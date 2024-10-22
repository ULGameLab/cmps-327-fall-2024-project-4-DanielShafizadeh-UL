using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Alighnment : MonoBehaviour
{
    float minDist = 0.5f;
    public GameObject prefab;
    public int numObjs = 8;
    public GameObject[] objs;
    public Vector3 limits = new Vector3(2, 2, 2);
    public Vector3 goal=Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        objs = new GameObject[numObjs];
        for (int i = 0; i < numObjs; i++)
        {
            Vector3 posi = this.transform.position + new Vector3(Random.Range(-limits.x, limits.x), Random.Range(-limits.y, limits.y), Random.Range(-limits.z, limits.z));
            objs[i] = Instantiate(prefab, posi, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 10)
        {
            goal= this.transform.position + new Vector3(Random.Range(-limits.x, limits.x), Random.Range(-limits.y, limits.y), Random.Range(-limits.z, limits.z));
            
            
        }
        this.transform.Translate(0, 0, Time.deltaTime * Random.Range(0.05f, 3.0f));
        separateObjs();
    }
    void separateObjs()
    {
        Vector3 cent = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float speed = 0.01f;
        float dist;
        float groupsize = 0;
        foreach (GameObject obj in objs)
        {
            if (obj != this.gameObject)
            {
                dist = Vector3.Distance(obj.transform.position, this.transform.position);
                if (dist <= minDist)
                {
                    cent += obj.transform.position;
                    groupsize++;
                    if (dist > minDist)
                    {
                        avoid = avoid + (this.transform.position - obj.transform.position) / dist;

                    }
                    if (groupsize > 0)
                    {
                        cent = cent / groupsize+(goal-this.transform.position);
                        speed = speed / groupsize;
                        if (speed > 3.0f)
                        {
                            speed = 3.0f;
                        }
                        Vector3 dir = (cent + avoid) - transform.position;
                        if (dir != Vector3.zero)
                        {
                            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f * Time.deltaTime);
                        }
                    }

                }
            }
        }
    }
}
