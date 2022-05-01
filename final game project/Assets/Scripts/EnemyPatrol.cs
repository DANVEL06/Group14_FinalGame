using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform [] waypoints;
    public int speed;

    private int wayPointIndex;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        wayPointIndex =0;
        transform.LookAt(waypoints[wayPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        wayPointIndex++;
        if(wayPointIndex >=waypoints.Length)
        {
            wayPointIndex =0;
        }
        transform.LookAt(waypoints[wayPointIndex].position);
    }
}
